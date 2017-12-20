using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.HistoryOrders;
using DomainModel.Misc;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class TradingHistoryModel : ITradingHistoryModel
    {
        private readonly IModel _domainModel;

        public TradingHistoryModel(IModel domainModel)
        {
            _domainModel = domainModel;

            Filter = Default.Instance.TradingHistoryFilter;
        }

        public IEnumerable<Market> Markets => _domainModel.Markets;

        public IEnumerable<Pair> Pairs
        {
            get
            {
                var result = new List<Pair>();

                foreach (var market in Markets)
                {
                    result.AddRange(market.Pairs.Select(p => p.Pair));
                }

                var sorted = result.Where(p => p != null).GetSorted();
                return sorted.Distinct(new PairComparer());
            }
        }

        private IHistoryOrdersUpdaterProvider HistoryOrdersUpdaterProvider => _domainModel.HistoryOrdersProvider;

        private readonly List<IUpdater<IEnumerable<HistoryOrder>, Market>> _historyOrdersUpdaters =
            new List<IUpdater<IEnumerable<HistoryOrder>, Market>>();

        private readonly TimeInterval _historyOrdersRefreshInterval = TimeInterval.InMinutes(1);

        private HistoryOrdersFilter _filter;

        public HistoryOrdersFilter Filter
        {
            get { return _filter; }
            set
            {
                if (Filter == null || value.Market != Filter.Market)
                {
                    InitHistoryOrdersUpdater(value.Market);
                }

                _filter = value;

                ChangedHistoryOrders();
            }
        }

        private void InitHistoryOrdersUpdater(Market market = null)
        {
            ReleaseHistoryOrdersUpdater();

            var markets = new List<Market>();
            markets.AddRange(market != null ? new[] { market } : _domainModel.Markets);
            foreach (var market1 in markets)
            {
                var updater = HistoryOrdersUpdaterProvider.GetUpdater(market1, _historyOrdersRefreshInterval);
                updater.Changed += HistoryOrdersUpdater_Changed;
                _historyOrdersUpdaters.Add(updater);

                updater.Start();
            }
        }

        public IEnumerable<HistoryOrder> HistoryOrders { get; set; }

        private void SetHistoryOrders(IEnumerable<HistoryOrder> historyOrders)
        {
            HistoryOrders = historyOrders;
            OnHistoryOrdersChanged();
        }

        private void OnHistoryOrdersChanged()
        {
            HistoryOrdersChanged?.Invoke(HistoryOrders);
        }

        public double? GetUsdRateChanged(Currency currency)
        {
            var market = Filter.Market ?? Markets.FirstOrDefault();

            return market?.UsdEquivalent.UsdRate(currency);
        }

        public event Action<IEnumerable<HistoryOrder>> HistoryOrdersChanged;

        public void Release()
        {
            ReleaseHistoryOrdersUpdater();
        }

        private readonly List<HistoryOrder> _allHistoryOrders = new List<HistoryOrder>();

        private void HistoryOrdersUpdater_Changed(object sender, IEnumerable<HistoryOrder> historyOrders)
        {
            lock (_allHistoryOrders)
            {
                var updater = sender as IUpdater<IEnumerable<HistoryOrder>, Market>;
                Debug.Assert(updater != null);

                var market = updater.OwnerFeature;
                _allHistoryOrders.RemoveAll(h => h.Market == market);
                _allHistoryOrders.AddRange(historyOrders);

                ChangedHistoryOrders();
            }
        }

        private void ChangedHistoryOrders()
        {
            SetHistoryOrders(ApplyFilter(_allHistoryOrders).OrderByDescending(o => o.Time));
        }

        private IEnumerable<HistoryOrder> ApplyFilter(List<HistoryOrder> allHistoryOrders)
        {
            IEnumerable<HistoryOrder> result = allHistoryOrders.ToArray();

            if (Filter.Pair != null)
                result = result.Where(o => o.Pair.Equals(Filter.Pair));

            if (Filter.Position != null)
                result = result.Where(o => o.Position == Filter.Position.Value);

            if (Filter.Period != null)
            {
                DateTime period;
                switch (Filter.Period)
                {
                    case Period.Hours12:
                        period = DateTime.Now - TimeSpan.FromHours(12);
                        break;

                    case Period.Day1:
                        period = DateTime.Now - TimeSpan.FromDays(1);
                        break;

                    case Period.Day3:
                        period = DateTime.Now - TimeSpan.FromDays(3);
                        break;

                    case Period.Day7:
                        period = DateTime.Now - TimeSpan.FromDays(7);
                        break;

                    case Period.Month1:
                        period = DateTime.Now - TimeSpan.FromDays(30);
                        break;

                    case Period.Month3:
                        period = DateTime.Now - TimeSpan.FromDays(90);
                        break;

                    case Period.Month6:
                        period = DateTime.Now - TimeSpan.FromDays(30 * 6);
                        break;

                    case Period.Year1:
                        period = DateTime.Now - TimeSpan.FromDays(30 * 12);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                result = result.Where(o => o.Time >= period);
            }

            return result;
        }

        private void ReleaseHistoryOrdersUpdater()
        {
            foreach (var updater in _historyOrdersUpdaters)
            {
                HistoryOrdersUpdaterProvider.ReleaseUpdater(updater);
                updater.Changed -= HistoryOrdersUpdater_Changed;
            }
            _historyOrdersUpdaters.Clear();
            _allHistoryOrders.Clear();
        }
    }
}