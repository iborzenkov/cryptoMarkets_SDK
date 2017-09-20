namespace DomainModel
{
    public enum OrderBookType
    {
        Buy,
        Sell,
        Both
    }

    public enum OrderBookSort
    {
        Increase,
        Decrease
    }

    public enum TradePosition
    {
        Buy,
        Sell
    }

    public enum PriceTypeEnum
    {
        Market,
        Limit
    }

    public enum QuantityTypeEnum
    {
        Quantity,
        Spending,
        UsdSpending,
        AllAvailable
    }
}