using System;

namespace DomainModel.Features
{
    public class MarketHistory
    {
        public Pair Pair { get; }
        public string Id { get; }
        public TradePosition OrderType { get; }
        public double Total { get; }
        public double Price { get; }
        public double Quantity { get; }
        public DateTime TimeStamp { get; }

        public MarketHistory(Pair pair, string id, DateTime timeStamp, double quantity, double price,
            double total, TradePosition orderType)
        {
            Pair = pair;
            Id = id;
            TimeStamp = timeStamp;
            Quantity = quantity;
            Price = price;
            Total = total;
            OrderType = orderType;
        }
    }
}