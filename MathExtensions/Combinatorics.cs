using System.Collections.Generic;
using System.Linq;

namespace TommasoScalici.MathExtensions
{
    /// <summary>
    /// Define if elements are repeated or not in a combinatoric operation.
    /// </summary>
    public enum GenerateOptions
    {
        /// <summary>
        /// Repetitions are taken in consideration.
        /// </summary>
        WithRepetition,

        /// <summary>
        /// Repetitions are excluded.
        /// </summary>
        WithoutRepetition,
    }

    /// <summary>
    /// Static class that contains methods for combinatorics such combinations and permutations.
    /// </summary>
    public static class Combinatorics
    {
        /// <summary>
        /// Generate a <paramref name="k" />-combination of <paramref name="source"/> with the chosen <paramref name="generateOption"/>.
        /// </summary>
        /// <typeparam name="T">The elements type of the set you want to combine.</typeparam>
        /// <param name="source">The source set.</param>
        /// <param name="k">The size of the groups.</param>
        /// <param name="generateOption">Specify if you want repetition or not.</param>
        /// <returns>A subset of <paramref name="k"/> distinct elements (where order matters) of <paramref name="source"/></returns>
        public static IEnumerable<IEnumerable<T>> Combine<T>(this IEnumerable<T> source, int k, GenerateOptions generateOption) =>
            k > source.Count() ? new[] { new T[] { } } :
            k == 0 ? new[] { new T[0] } :
            generateOption == GenerateOptions.WithRepetition ?
            source.SelectMany((e, i) => source.Skip(i).Combine(k - 1, generateOption), (e, c) => new[] { e }.Concat(c)) :
            source.SelectMany((e, i) => source.Skip(i + 1).Combine(k - 1, generateOption), (e, c) => new[] { e }.Concat(c));

        /// <summary>
        /// Generate a <paramref name="k"/>-partial permutation of <paramref name="source"/> with the chosen
        /// <paramref name="generateOption"/>.
        /// </summary>
        /// <typeparam name="T">The elements type of the set you want to partial permute.</typeparam>
        /// <param name="source">The source set.</param>
        /// <param name="k">The size of the groups.</param>
        /// <param name="generateOption">Specify if you want repetition or not.</param>
        /// <returns>Subsets of distinct elements in <paramref name="source"/> taken at groups of <paramref name="k"/>
        /// (where order doesn't matter)</returns>
        public static IEnumerable<IEnumerable<T>> PartialPermute<T>(this IEnumerable<T> source, int k, GenerateOptions generateOption) =>
            k > source.Count() ? new[] { new T[] { } } :
            k == 0 ? new[] { new T[0] } :
            generateOption == GenerateOptions.WithRepetition ?
            source.SelectMany((e, i) => source.PartialPermute(k - 1, generateOption), (e, p) => new[] { e }.Concat(p)) :
            source.SelectMany((e, i) => source.Except(new[] { e }).PartialPermute(k - 1, generateOption), (e, p) => new[] { e }.Concat(p));

        /// <summary>
        /// Generate a permutation of <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="T">The elements type of the set you want to permute.</typeparam>
        /// <param name="source">The source set.</param>
        /// <returns>All the possible orderings of the elements in <paramref name="source"/></returns>
        /// 
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> source) =>
            source.Count() == 1 ? new[] { source } :
            source.SelectMany((e1, i1) => source.Where((e2, i2) => i1 != i2).Permute(), (e, p) => new[] { e }.Concat(p));
    }
}
