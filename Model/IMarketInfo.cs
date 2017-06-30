using System.Collections.Generic;
using Model.Features;

namespace Model
{
    public interface IMarketInfo
    {
        IEnumerable<Market> Markets();
        IEnumerable<Currency> Currencies();
        Tick Tick(Pair pair);
    }
}