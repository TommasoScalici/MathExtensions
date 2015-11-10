using System.Collections.Generic;

namespace TommasoScalici.LINQExtensions
{
    public static class SequenceGeneration
    {
        public static IEnumerable<long> Fibonacci(long minValue = 0, long maxValue = long.MaxValue)
        {
            long prev = -1;
            long next = 1;

            while (prev <= maxValue)
            {
                long sum = prev + next;

                if (sum < 0)
                    break;

                prev = next;
                next = sum;

                if (sum < minValue)
                    continue;

                yield return sum;
            }
        }
    }
}
