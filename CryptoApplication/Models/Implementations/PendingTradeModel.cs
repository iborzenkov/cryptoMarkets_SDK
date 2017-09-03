using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class PendingTradeModel : IPendingTradeModel
    {
        private readonly IModel _domainModel;

        public PendingTradeModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> IPendingTradeModel.Markets => _domainModel.Markets;

        public void NeedOrderBookOf(PairOfMarket pair)
        {
        }

        public void NeedBalanceOf(CurrencyOfMarket currency)
        {
        }
    }
}