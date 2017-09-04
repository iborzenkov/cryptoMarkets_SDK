using System;

namespace DomainModel.Features
{
    public class Order
    {
        public OrderId Id { get; set; }
        public Pair Pair { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public TradePosition Position { get; set; }
        public DateTime Opened { get; set; }
    }
}