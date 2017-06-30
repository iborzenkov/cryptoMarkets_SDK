using System;

namespace Model.Features
{
    public class Market : IEquatable<Market>
    {
        public Pair Pair { get; }

        public double MinTradeSize { get; }

        public bool IsActive { get; }

        public DateTime? Created { get; }

        public Market(Pair pair, double minTradeSize) :
            this(pair, minTradeSize, true, null)
        {
        }

        public Market(Pair pair, double minTradeSize, bool isActive) :
            this(pair, minTradeSize, isActive, null)
        {
        }

        public Market(Pair pair, double minTradeSize, bool isActive,
            DateTime? created)
        {
            Pair = pair;
            MinTradeSize = minTradeSize;
            IsActive = isActive;
            Created = created;
        }

        public bool Equals(Market other)
        {
            return other != null && Pair.Equals(other.Pair);
        }

        public override string ToString()
        {
            return Pair.ToString();
        }
    }
}