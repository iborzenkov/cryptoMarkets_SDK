using DomainModel;
using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class TradeModel : ITradeModel
    {
        private readonly IModel _domainModel;

        public TradeModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> ITradeModel.Markets => _domainModel.Markets;
        public void NeedOrderBookOf(PairOfMarket pair)
        {
            throw new NotImplementedException();
        }

        public void NeedBalanceOf(CurrencyOfMarket currency)
        {
            throw new NotImplementedException();
        }
    }
}