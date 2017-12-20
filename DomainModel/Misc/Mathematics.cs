using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Misc
{
    public static class Mathematics
    {
        public static double Percentile(double[] sequence, double percentile)
        {
            const double tolerance = 0.00000001;

            Array.Sort(sequence);
            var length = sequence.Length;
            var n = (length - 1) * percentile + 1;

            if (Math.Abs(n - 1d) < tolerance)
                return sequence[0];
            if (Math.Abs(n - length) < tolerance)
                return sequence[length - 1];

            var k = (int)n;
            var d = n - k;
            return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="largeVolumeKoef">0.01 .. 0.49</param>
        /// <returns></returns>
        public static IEnumerable<int> LargeIndexes(IEnumerable<double> numbers, double largeVolumeKoef)
        {
            var result = new List<int>();

            var numbersArray = numbers.ToArray();
            if (!numbersArray.Any())
                return result;

            var copyArray = numbersArray.ToArray();
            var firstPercentile = Percentile(copyArray, 0.5 - largeVolumeKoef);
            var thirdPercentile = Percentile(copyArray, 0.5 + largeVolumeKoef);
            var diff = thirdPercentile - firstPercentile;
            var maxLimit = thirdPercentile + 3 * diff;

            for (var i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] >= maxLimit)
                    result.Add(i);
            }
            return result;
        }
    }
}