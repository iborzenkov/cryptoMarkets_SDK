namespace CryptoSdk.Bittrex.Connection
{
    public class EndPoints
    {
        public static string Main { get; } = "https://bittrex.com/api/v1.1/";
        public static string GetMarkets { get; } = "public/getmarkets";
        public static string GetCurrencies { get; } = "public/getcurrencies";
        public static string GetTicker { get; } = "public/getticker";
        public static string GetMarketSummary { get; } = "public/getmarketsummary";
        public static string GetMarketSummaries { get; } = "public/getmarketsummaries";
        public static string GetOrderBook { get; } = "public/getorderbook";
        public static string GetBalances { get; } = "account/getbalances";
        public static string GetBalance { get; } = "account/getbalance";
        public static string BuyLimit { get; } = "market/buylimit";
        public static string SellLimit { get; } = "market/selllimit";
        public static string CancelOrder { get; } = "market/cancel";
        public static string GetOpenedOrders { get; } = "market/getopenorders";
    }
}