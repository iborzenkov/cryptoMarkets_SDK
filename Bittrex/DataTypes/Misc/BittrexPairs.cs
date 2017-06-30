using Model.Features;

namespace Bittrex.DataTypes.Misc
{
    internal class BittrexPairs
    {
        public static string AsString(Pair pair)
        {
            return $"{pair.BaseCurrency.Name}-{pair.QuoteCurrency.Name}";
        }
    }
}