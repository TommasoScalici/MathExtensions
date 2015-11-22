using System;
using System.Collections.Generic;
using System.Linq;

namespace TommasoScalici.LINQExtensions
{
    public static class EnumerableExtensions
    {
        static readonly Random random = new Random();


        public static T RandomOrDefault<T>(this IEnumerable<T> source) => source.ElementAtOrDefault(random.Next(source.Count()));

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var sourceList = source.ToList();
            sourceList.Shuffle();
            return sourceList;
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            var alreadyPickedList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                if (i >= source.Count())
                    break;

                var uniqueRandomElement = source.Except(alreadyPickedList).RandomOrDefault();
                alreadyPickedList.Add(uniqueRandomElement);
                yield return uniqueRandomElement;
            }
        }

        public static IEnumerable<T> TakeRandomWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var alreadyPickedList = new List<T>();

            for (int i = 0; i < source.Count(); i++)
            {
                var uniqueRandomElement = source.Except(alreadyPickedList).RandomOrDefault();
                alreadyPickedList.Add(uniqueRandomElement);

                if (predicate(uniqueRandomElement))
                    yield return uniqueRandomElement;
                else
                    break;
            }
        }

        static void Shuffle<T>(this IList<T> source)
        {
            var count = source.Count;

            while (count > 1)
            {
                var i = random.Next(count--);
                T temp = source[count];
                source[count] = source[i];
                source[i] = temp;
            }
        }
    }
}
