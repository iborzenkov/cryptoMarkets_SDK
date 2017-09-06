using System;

namespace DomainModel
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
    }
}