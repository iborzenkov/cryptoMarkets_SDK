﻿namespace DomainModel
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

    public enum TimeframeType
    {
        M1,
        M5,
        M15,
        M30, 
        H1,
        H4,
        D1,
    }

}