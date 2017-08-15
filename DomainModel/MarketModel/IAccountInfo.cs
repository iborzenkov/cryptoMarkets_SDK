using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel
{
    public interface IAccountInfo
    {
        IApiKey ApiKey { get; set; }

        IEnumerable<Balance> Balances(Market market);

        Balance Balance(Market market, Currency currency);

        Balance Balance(CurrencyOfMarket currency);
    }
}