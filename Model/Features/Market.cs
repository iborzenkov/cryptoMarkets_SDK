using System;

namespace Model.Features
{
    public class Market
    {
        public Pair Pair { get; set; }

        public double MinTradeSize { get; set; }
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }

        public Market(Pair pair, double minTradeSize, bool isActive) : 
            this(pair, minTradeSize, isActive, DateTime.MinValue)
        {
        }

        public Market(Pair pair, double minTradeSize, bool isActive,
            DateTime created)
        {
            Pair = pair;
            MinTradeSize = minTradeSize;
            IsActive = isActive;
            Created = created;
        }

        public override string ToString()
        {
            return Pair.ToString();
        }
    }
}