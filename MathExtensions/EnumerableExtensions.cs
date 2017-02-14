using System;
using System.Collections.Generic;
using System.Linq;

namespace TommasoScalici.MathExtensions
{
    /// <summary>
    /// Static class that contains various extension methods for <seealso cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        static readonly Random random = new Random();

        /// <summary>
        /// Take a random element from the source.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>A random element taken from the source.</returns>
        /// <exception cref="ArgumentNullException">If source is null.</exception>
        public static T RandomOrDefault<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return source.ElementAtOrDefault(random.Next(source.Count()));
        }

        /// <summary>
        /// Changes the source listed elements order randomly.
        /// <para><b>Note:</b>
        /// though this is a chain-able method in LINQ style, the original list's order will be also shuffled.
        /// </para>
        /// </summary>
        /// <typeparam name="T">Type of the elements in the source.</typeparam>
        /// <param name="source">The source list.</param>
        /// <returns>The same list passed after the shuffle.</returns>
        /// <exception cref="ArgumentNullException">If source is null.</exception>
        /// <remarks>Note: though this is a chain-able method in LINQ style, the original list's order will be also shuffled.</remarks>
        public static IList<T> Shuffle<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var count = source.Count;

            while (count > 1)
            {
                var i = random.Next(count--);
                var temp = source[count];
                source[count] = source[i];
                source[i] = temp;
            }

            return source;
        }

        /// <summary>
        /// Works as <see cref="System.Linq.Enumerable.Take{TSource}(IEnumerable{TSource}, int)"/> but it takes random elements.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="count">The number of elements to take randomly.</param>
        /// <returns>Random element(s) taken from source.</returns>
        /// <exception cref="ArgumentNullException">If source is null.</exception>
        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var alreadyPickedList = new List<T>();

            for (var i = 0; i < count; i++)
            {
                if (i >= source.Count())
                    break;

                var uniqueRandomElement = source.Except(alreadyPickedList).RandomOrDefault();
                alreadyPickedList.Add(uniqueRandomElement);
                yield return uniqueRandomElement;
            }
        }

        /// <summary>
        /// Works as <see cref="System.Linq.Enumerable.TakeWhile{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// but it takes random elements.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate that needs to be satisfied for taking elements.</param>
        /// <returns>Random element(s) taken from source while <paramref name="predicate" /> is true.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="source"/> or <paramref name="predicate"/> are null.</exception>
        public static IEnumerable<T> TakeRandomWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var alreadyPickedList = new List<T>();

            for (var i = 0; i < source.Count(); i++)
            {
                var uniqueRandomElement = source.Except(alreadyPickedList).RandomOrDefault();
                alreadyPickedList.Add(uniqueRandomElement);

                if (predicate(uniqueRandomElement))
                    yield return uniqueRandomElement;
                else
                    break;
            }
        }
    }
}
