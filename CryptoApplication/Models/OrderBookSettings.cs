using DomainModel;

namespace Models
{
    public class OrderBookSettings
    {
        public int RefreshInterval { get; set; }
        public OrderBookType OrderBookType { get; set; }
        public int Multiplier { get; set; }
        public int Depth { get; set; }
    }
}