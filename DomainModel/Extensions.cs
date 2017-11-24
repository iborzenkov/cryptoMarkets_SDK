using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Features;

namespace DomainModel
{
    public static class Extensions
    {
        public static int ToMinutes(this TimeframeType timeframe)
        {
            switch (timeframe)
            {
                case TimeframeType.M1:
                    return 1;

                case TimeframeType.M5:
                    return 5;

                case TimeframeType.M15:
                    return 15;

                case TimeframeType.M30:
                    return 30;

                case TimeframeType.H1:
                    return 60;

                case TimeframeType.H2:
                    return 120;

                case TimeframeType.H4:
                    return 240;

                case TimeframeType.D1:
                    return 1440;

                default:
                    throw new ArgumentOutOfRangeException(nameof(timeframe), timeframe, null);
            }
        }

        public static IEnumerable<PairOfMarket> ActiveOnly(this IEnumerable<PairOfMarket> pairs)
        {
            return pairs.Where(p => p.IsActive);
        }
    }
}