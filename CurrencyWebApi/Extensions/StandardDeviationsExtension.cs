using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyWebApi.Extensions
{
    public static class StandardDeviationsExtension
    {
        public static double StandardDeviation(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source cannot be null");
            }

            return CalcStdDeviation(source);
        }



        public static double StandardDeviation<TSource>(this IEnumerable<TSource> source,
            Func<TSource, double> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source cannot be null");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("Selector cannot be null");
            }
            var enumerable = source.Select(selector).ToList();
            return CalcStdDeviation(enumerable);
        }


        private static double CalcStdDeviation(IEnumerable<double> source)
        {
            var enumerable = source.ToList();
            int count = enumerable.Count();
            if (count <= 0)
                return 0;
            double avg = enumerable.Average();
            var stdDev = Math.Sqrt(enumerable.Sum(a => Math.Pow((a - avg), 2)) / count);
            return stdDev;
        }

    }
}