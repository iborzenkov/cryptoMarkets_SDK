using System;

namespace DomainModel.Features
{
    public class Order
    {
        public OrderId Id { get; }
        public Market Market { get; }
        public Pair Pair { get; }
        public double Quantity { get; }
        public double Price { get; }
        public TradePosition Position { get; }
        public DateTime? Opened { get; }

        public Order(OrderId id, Market market, Pair pair, double quantity, double price, TradePosition position) 
            : this(id, market, pair, quantity, price, position, null)
        {
        }

        public Order(OrderId id, Market market, Pair pair, double quantity, double price, TradePosition position, DateTime? opened)
        {
            Id = id;
            Market = market;
            Pair = pair;
            Quantity = quantity;
            Price = price;
            Position = position;
            Opened = opened;
        }
    }
}