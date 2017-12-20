using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.Misc
{
    public class PairComparer : IEqualityComparer<Pair>
    {
        public bool Equals(Pair x, Pair y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Equals(y);
        }

        public int GetHashCode(Pair pair)
        {
            return pair.BaseCurrency.Name.GetHashCode() ^ pair.QuoteCurrency.Name.GetHashCode();
        }
    }
}