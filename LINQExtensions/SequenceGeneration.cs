using System.Collections.Generic;

namespace TommasoScalici.LINQExtensions
{
    /// <summary>
    /// Static class that contains methods for sequence generation.
    /// </summary>
    public static class SequenceGeneration
    {
        /// <summary>
        /// Generate Fibonacci numbers between the two constraints passed as parameters.
        /// </summary>
        /// <param name="minValue">The minimum value from which to start the sequence generation.</param>
        /// <param name="maxValue">The maximum value where the sequence generation has to stop.</param>
        /// <returns>The Fibonacci sequence between the chosen constraints.</returns>
        public static IEnumerable<long> Fibonacci(long minValue = 0, long maxValue = long.MaxValue)
        {
            long prev = -1;
            long next = 1;

            while (true)
            {
                long sum = prev + next;

                if (sum < 0 || sum > maxValue)
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
