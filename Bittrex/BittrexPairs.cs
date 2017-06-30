using Model.Features;

namespace BittrexModel
{
    internal class BittrexPairs
    {
        public static string AsString(Pair pair)
        {
            return $"{pair.BaseCurrency.ShortName}-{pair.QuoteCurrency.ShortName}";
        }
    }
}