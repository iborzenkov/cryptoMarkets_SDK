using DomainModel.MarketModel;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public class Market
    {
        public IMarketModel Model { get; }

        public Market(string name, IMarketModel model)
        {
            Name = name;
            Model = model;
        }

        private IEnumerable<PairOfMarket> _pairs;
        private IEnumerable<CurrencyOfMarket> _currencies;

        public string Name { get; }
        public IEnumerable<PairOfMarket> Pairs => _pairs ?? (_pairs = Model.Info.Pairs(this));
        public IEnumerable<CurrencyOfMarket> Currencies => _currencies ?? (_currencies = Model.Info.Currencies(this));
    }
}