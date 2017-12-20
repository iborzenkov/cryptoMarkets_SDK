using System;

namespace DomainModel.Features
{
    public class HistoryOrder
    {
        public OrderId Id { get; }
        public Market Market { get; }
        public Pair Pair { get; }
        public double Quantity { get; }
        public double Price { get; }
        public double Fee { get; }
        public TradePosition Position { get; }
        public DateTime? Time { get; }


        public HistoryOrder(OrderId id, Market market, Pair pair, double quantity, double price, double fee, 
            TradePosition position, DateTime? time)
        {
            Id = id;
            Market = market;
            Pair = pair;
            Quantity = quantity;
            Fee = fee;
            Price = price;
            Position = position;
            Time = time;
        }
    }
}