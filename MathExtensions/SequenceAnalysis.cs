using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TommasoScalici.MathExtensions
{
    /// <summary>
    /// Define the kind of a mathematical sequence.
    /// </summary>
    [Flags]
    public enum SequenceKind
    {
        /// <summary>
        /// No pattern.
        /// </summary>
        None = 0,

        /// <summary>
        /// An arithmetic sequence pattern.
        /// </summary>
        Arithmetic,

        /// <summary>
        /// A geometric sequence pattern.
        /// </summary>
        Geometric,

        /// <summary>
        /// Multiple patterns.
        /// </summary>
        Indeterminable = Arithmetic | Geometric,

        /// <summary>
        /// Fibonacci sequence pattern.
        /// </summary>
        Fibonacci,

        /// <summary>
        /// A triangular sequence pattern.
        /// </summary>
        Triangular,
    }

    /// <summary>
    /// Static class that contains methods for sequence analysis.
    /// </summary>
    public static class SequenceAnalysis
    {
        /// <summary>
        /// Tries to find a pattern in the sequence passed as parameter.
        /// </summary>
        /// <typeparam name="T">The type of elements in the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The <seealso cref="SequenceKind"/> found.</returns>
        /// <exception cref="ArgumentNullException">If source is null.</exception>
        /// <exception cref="NotSupportedException">If <typeparamref name="T"/> is not primitive.</exception>
        public static SequenceKind FindSequenceKind<T>(this IEnumerable<T> source) where T : IComparable<T>, IEquatable<T>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!typeof(T).GetTypeInfo().IsPrimitive && typeof(T) != typeof(decimal))
                throw new NotSupportedException("Only primitive types are supported.");

            var sequenceKind = SequenceKind.None;

            if (source.Count() == 1)
                return sequenceKind;

            var numericList = new List<long>();
            var sourceList = source.ToList();

            var arithmeticDifference = new List<dynamic>();
            var geometricDifference = new List<dynamic>();

            for (var i = 0; i < sourceList.Count - 1; i++)
            {
                arithmeticDifference.Add((dynamic)sourceList[i + 1] - sourceList[i]);
                geometricDifference.Add((dynamic)sourceList[i + 1] % sourceList[i]);
            }

            numericList = sourceList.Select(x => (long)(dynamic)x).ToList();

            var fibonacci = SequenceGeneration.Fibonacci(numericList.FirstOrDefault(), numericList.LastOrDefault());
            var triangular = SequenceGeneration.Triangular(numericList.FirstOrDefault(), numericList.LastOrDefault());

            if (fibonacci.SequenceEqual(numericList))
                sequenceKind |= SequenceKind.Fibonacci;

            if (triangular.SequenceEqual(numericList))
                sequenceKind |= SequenceKind.Triangular;

            if (arithmeticDifference.All(x => x == arithmeticDifference.FirstOrDefault()))
                sequenceKind |= SequenceKind.Arithmetic;

            if (geometricDifference.All(x => x == geometricDifference.FirstOrDefault()))
                sequenceKind |= SequenceKind.Geometric;

            return sequenceKind;
        }
    }
}
