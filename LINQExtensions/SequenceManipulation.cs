using System;
using System.Collections.Generic;
using System.Linq;

namespace TommasoScalici.LINQExtensions
{
    public static class SequenceManipulation
    {
        static Random random = new Random();


        public static T RandomOrDefault<T>(this IEnumerable<T> source)
        {
            return source.ElementAtOrDefault(random.Next(source.Count()));
        }

        public static void Shuffle<T>(this IList<T> source)
        {
            var count = source.Count();

            while (count > 1)
            {
                var i = random.Next(count--);
                T temp = source[count];
                source[count] = source[i];
                source[i] = temp;
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var sourceList = source.ToList();
            sourceList.Shuffle();
            return sourceList;
        }
    }
}
