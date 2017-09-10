using DomainModel.Features;
using DomainModel.MarketModel.Updaters.PairStatistic;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class PairModel : IPairModel
    {
        private readonly IModel _domainModel;
        private Market _selectedMarket;

        public PairModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        private IPairStatisticUpdaterProvider PairStatisticUpdaterProvider => _domainModel.PairStatisticUpdaterProvider;

        Market IPairModel.SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                if (_selectedMarket == value)
                    return;

                _selectedMarket = value;
                NeedStatisticsOf(_selectedMarket);
                //OnPairsChanged(_selectedMarket?.Pairs);
            }
        }

        private void NeedStatisticsOf(Market market)
        {
            if (market == null)
            {
                Statistics = null;
                OnStatisticChanged();
                return;
            }

            if (_updater != null)
            {
                PairStatisticUpdaterProvider.ReleaseUpdater(_updater);
                _updater.Changed -= PairStatisticUpdater_Changed;
            }

            _updater = PairStatisticUpdaterProvider.PairStatisticUpdater(market);
            _updater.Changed += PairStatisticUpdater_Changed;
            if (_updater.LastPairsStatistic != null)
                SetStatistics(_updater.LastPairsStatistic);

            _updater.Start();
        }

        private void PairStatisticUpdater_Changed(object sender, IEnumerable<PairStatistic> statistics)
        {
            SetStatistics(statistics);
        }

        private void SetStatistics(IEnumerable<PairStatistic> statistics)
        {
            Statistics = statistics;
            OnStatisticChanged();
        }

        public IEnumerable<PairStatistic> Statistics { get; set; }

        private void OnStatisticChanged()
        {
            StatisticsChanged?.Invoke(Statistics);
        }

        public event Action<IEnumerable<PairStatistic>> StatisticsChanged;

        IEnumerable<Market> IPairModel.Markets => _domainModel.Markets;
        private IPairStatisticUpdater _updater;

        void IPairModel.SetFilter(PairViewFilter filter)
        {
            IPairModel model = this;
            if (model.SelectedMarket == null)
            {
                OnPairsChanged(null);
                return;
            }

            var token = filter.PairToken;

            var allPairs = model.SelectedMarket.Pairs;
            var filtered = filter.IsActiveOnly ? allPairs.Where(c => c.IsActive) : allPairs;
            filtered = string.IsNullOrEmpty(token)
                ? filtered
                : filtered.Where(p =>
                    p.Pair.BaseCurrency.Name.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.Pair.QuoteCurrency.Name.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0);

            var result = new List<PairOfMarket>();
            foreach (var pair in filtered)
            {
                if (Statistics == null)
                {
                    result.Add(pair);
                    continue;
                }

                var stats = Statistics.FirstOrDefault(s => s.Pair.Equals(pair.Pair));

                switch (filter.DailyChange)
                {
                    case DailyChangePairEnum.PositiveOnly:
                        if (stats != null && stats.DailyChangeOfLastPrice() > 0)
                            result.Add(pair);
                        break;
                    case DailyChangePairEnum.NegativeOnly:
                        if (stats != null && stats.DailyChangeOfLastPrice() < 0)
                            result.Add(pair);
                        break;
                    default:
                        result.Add(pair);
                        break;
                }
            }

            OnPairsChanged(result);
        }

        public event Action<IEnumerable<PairOfMarket>> PairsChanged;

        private void OnPairsChanged(IEnumerable<PairOfMarket> pairs)
        {
            PairsChanged?.Invoke(pairs);
        }

        void IPairModel.Release()
        {
            PairStatisticUpdaterProvider.ReleaseUpdater(_updater);
        }
    }
}