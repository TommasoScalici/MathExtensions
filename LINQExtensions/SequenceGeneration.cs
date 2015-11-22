using System.Collections.Generic;

namespace TommasoScalici.LINQExtensions
{
    /// <summary>
    /// Static class that contains methods for sequence generation.
    /// </summary>
    public static class SequenceGeneration
    {
        /// <summary>
        /// Generates an arithmetic sequence between the two constraints passed as parameters.
        /// </summary>
        /// <param name="k">The additive constant of the sequence.</param>
        /// <param name="minValue">The minimum value from which the sequence generation starts.</param>
        /// <param name="maxValue">The maximum value where the sequence generation has to stop.</param>
        /// <returns>The arithmetic sequence between the chosen constraints.</returns>
        public static IEnumerable<long> Arithmetic(int k, long minValue = 0, long maxValue = long.MaxValue)
        {
            for (long i = minValue; i <= maxValue; i += k)
                yield return i;
        }

        /// <summary>
        /// Generates Fibonacci numbers between the two constraints passed as parameters.
        /// </summary>
        /// <param name="minValue">The minimum value from which the sequence generation starts.</param>
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

        /// <summary>
        /// Generates a geometric sequence between the two constraints passed as parameters.
        /// </summary>
        /// <param name="k">The multiplicative constant of the sequence.</param>
        /// <param name="minValue">The minimum value from which the sequence generation starts.</param>
        /// <param name="maxValue">The maximum value where the sequence generation has to stop.</param>
        /// <returns>The geometric sequence between the chosen constraints.</returns>
        public static IEnumerable<long> Geometric(int k, long minValue = 1, long maxValue = long.MaxValue)
        {
            for (long i = minValue; i <= maxValue; i *= k)
                yield return i;
        }

        /// <summary>
        /// Generates prime numbers between the two constraints passed as parameters, using the Sieve of Eratosthenes algorithm.
        /// </summary>
        /// <param name="minValue">The minimum value from which the sequence generation starts.</param>
        /// <param name="maxValue">The maximum value where the sequence generation has to stop.</param>
        /// <returns>The prime numbers between the chosen constraints.</returns>
        public static IEnumerable<long> PrimeNumbers(long minValue = 0, long maxValue = long.MaxValue)
        {
            var isPrime = new bool[maxValue + 1];

            for (long i = 2; i <= maxValue; i++)
                isPrime[i] = true;

            for (long i = 2; i <= maxValue; i++)
            {
                if (isPrime[i])
                {
                    for (long j = i * 2; j <= maxValue; j += i)
                        isPrime[j] = false;
                }
            }

            for (long i = 2; i <= maxValue; i++)
                if (isPrime[i] && i >= minValue)
                    yield return i;
        }

        /// <summary>
        /// Generates a triangular sequence between the two constraints passed as parameters.
        /// </summary>
        /// <param name="minValue">The minimum value from which the sequence generation starts.</param>
        /// <param name="maxValue">The maximum value where the sequence generation has to stop.</param>
        /// <returns>The triangular sequence between the chosen constraints.</returns>
        public static IEnumerable<long> Triangular(long minValue = 0, long maxValue = long.MaxValue)
        {
            for (int i = 1; i < maxValue; i++)
            {
                var result = i * (i + 1) / 2;

                if (result < minValue)
                    continue;

                if (result > maxValue)
                    break;

                yield return result;
            }
        }
    }
}
