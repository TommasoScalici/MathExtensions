using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TommasoScalici.LINQExtensions
{
    [Flags]
    public enum SequenceKind
    {
        None = 0,
        Arithmetic,
        Geometric,
        ArithmeticOrGeometric = Arithmetic | Geometric,
        Fibonacci,
        Triangular
    }


    public static class SequenceAnalysis
    {
        public static SequenceKind FindSequenceKind<T>(this IEnumerable<T> source)
            where T : struct, IComparable, IComparable<T>, IEquatable<T>
        {
            var sequenceKind = SequenceKind.None;
            var numericList = new List<long>();
            var sourceList = source.ToList();

            var arithmeticDifference = new List<int>();
            var geometricDifference = new List<int>();

            try
            {
                for (int i = 0; i < sourceList.Count - 1; i++)
                {
                    arithmeticDifference.Add((dynamic)sourceList[i + 1] - sourceList[i]);
                    geometricDifference.Add((dynamic)sourceList[i + 1] % sourceList[i]);
                }

                numericList = sourceList.Select(x => (long)(dynamic)x).ToList();
                var fibonacci = SequenceGeneration.Fibonacci(numericList.LastOrDefault(), numericList.FirstOrDefault());

                if (fibonacci.SequenceEqual(numericList))
                    sequenceKind |= SequenceKind.Fibonacci;
            }
            
            catch
            {
                Debug.WriteLine("SequenceAnalysis.FindSequenceKind<T> warning: T is not numeric!");
            }

            if (arithmeticDifference.All(x => x == arithmeticDifference.FirstOrDefault()))
                sequenceKind |= SequenceKind.Arithmetic;

            if (geometricDifference.All(x => x == geometricDifference.FirstOrDefault()))
                sequenceKind |= SequenceKind.Geometric;

            return sequenceKind;
        }
    }
}
