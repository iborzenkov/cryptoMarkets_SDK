using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class MarketTradeModel : IMarketTradeModel
    {
        private readonly IModel _domainModel;

        public MarketTradeModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> IMarketTradeModel.Markets => _domainModel.Markets;

        public void NeedOrderBookOf(PairOfMarket pair)
        {
        }

        public void NeedBalanceOf(CurrencyOfMarket currency)
        {
        }
    }
}