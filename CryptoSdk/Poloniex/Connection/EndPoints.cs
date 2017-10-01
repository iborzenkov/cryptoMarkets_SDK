namespace CryptoSdk.Poloniex.Connection
{
    public class EndPoints
    {
        public static string CommandTag { get; } = "command";

        public static string Main { get; } = "https://poloniex.com/";
        public static string Public { get; } = "public";
        public static string Trading { get; } = "tradingApi";
        public static string GetTicker { get; } = "returnTicker";
        public static string GetCurrencies { get; } = "returnCurrencies";
        public static string GetOrderBook { get; } = "returnOrderBook";
        public static string GetMarketHistory { get; } = "returnTradeHistory";
        public static string GetBalances { get; } = "returnCompleteBalances";
        public static string GetPurseAddress { get; } = "returnDepositAddresses";
        public static string BuyLimit { get; } = "market/buylimit";
        public static string SellLimit { get; } = "market/selllimit";
        public static string CancelOrder { get; } = "market/cancel";
        public static string GetOpenedOrders { get; } = "returnOpenOrders";
    }
}