using System.Collections.Generic;
using System.Linq;

namespace TommasoScalici.LINQExtensions
{
    public enum GenerateOptions
    {
        WithRepetition,
        WithoutRepetion,
    }


    public static class Combinatorics
    {
        public static IEnumerable<IEnumerable<T>> Combine<T>(this IEnumerable<T> source, int k, GenerateOptions generateOption) =>
            k == 0 ? new[] { new T[0] } : generateOption == GenerateOptions.WithRepetition ?
            source.SelectMany((e, i) => source.Skip(i).Combine(k - 1, generateOption).Select(x => (new[] { e }).Concat(x))) :
            source.SelectMany((e, i) => source.Skip(i + 1).Combine(k - 1, generateOption).Select(c => (new[] { e }).Concat(c)));

        public static IEnumerable<IEnumerable<T>> PartialPermute<T>(this IEnumerable<T> source, int k, GenerateOptions generateOption) =>
            k == 0 ? new[] { new T[0] } : generateOption == GenerateOptions.WithRepetition ?
            source.SelectMany((e, i) => source.PartialPermute(k - 1, generateOption).Select(x => (new[] { e }).Concat(x))) :
            source.SelectMany((e, i) => source.Except(new[] { e }).PartialPermute(k - 1, generateOption).Select(c => (new[] { e }).Concat(c)));

        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> source, GenerateOptions generateOption) =>
            source.Count() == 1 ? new[] { source } : generateOption == GenerateOptions.WithRepetition ?
            source.SelectMany((e1, i1) => source.Where((e2, i2) => i1 != i2).Permute(generateOption), (e, p) => new[] { e }.Concat(p)) :
            source.SelectMany(e => source.Except(new[] { e }).Permute(generateOption), (e, p) => new[] { e }.Concat(p));
    }
}
