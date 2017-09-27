using DomainModel.Features;
using DomainModel.MarketModel.Updaters.PairStatistic;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.MarketModel.Updaters;
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
            ReleaseUpdater();

            if (market == null)
            {
                Statistics = null;
                OnStatisticChanged();
                return;
            }

            _statisticUpdater = PairStatisticUpdaterProvider.GetUpdater(market, _refreshInterval);
            _statisticUpdater.Changed += PairStatisticUpdater_Changed;
            if (_statisticUpdater.LastValue != null)
                SetStatistics(_statisticUpdater.LastValue);

            _statisticUpdater.Start();
        }

        private void ReleaseUpdater()
        {
            if (_statisticUpdater != null)
            {
                PairStatisticUpdaterProvider.ReleaseUpdater(_statisticUpdater);
                _statisticUpdater.Changed -= PairStatisticUpdater_Changed;
            }
        }

        private readonly TimeInterval _refreshInterval = TimeInterval.InMinutes(1);

        private void PairStatisticUpdater_Changed(ICollection<Pair24HoursStatistic> statistics)
        {
            SetStatistics(statistics);
        }

        private void SetStatistics(IEnumerable<Pair24HoursStatistic> statistics)
        {
            Statistics = statistics;
            OnStatisticChanged();
        }

        public IEnumerable<Pair24HoursStatistic> Statistics { get; set; }

        private void OnStatisticChanged()
        {
            StatisticsChanged?.Invoke(Statistics);
        }

        public event Action<IEnumerable<Pair24HoursStatistic>> StatisticsChanged;

        IEnumerable<Market> IPairModel.Markets => _domainModel.Markets;
        private IUpdater<ICollection<Pair24HoursStatistic>, Market> _statisticUpdater;

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
            ReleaseUpdater();
        }
    }
}