using System.Collections.Generic;
using CryptoSdk.Features;

namespace CryptoSdk
{
    public interface IMarketInfo
    {
        IEnumerable<Market> Markets();

        /// <summary>
        /// Returns the list of currencies traded on the exchange
        /// </summary>
        IEnumerable<Currency> Currencies();

        /// <summary>
        /// Returns the current quotation of the currency pair
        /// </summary>
        /// <param name="pair">Сurrency pair</param>
        Tick Tick(Pair pair);

        /// <summary>
        /// Returns the orderbook of the currency pair
        /// </summary>
        /// <param name="pair">Сurrency pair</param>
        /// <param name="orderBookType">Displayed part of the orderbook </param>
        /// <param name="depth">The depth of orderbook</param>
        OrderBook OrderBook(Pair pair, int depth = 10, OrderBookType orderBookType = OrderBookType.Both);
    }
}