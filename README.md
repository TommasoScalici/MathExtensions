# LINQ Extensions

LINQ extensions for .NET is a collection of useful extensions methods that extends LINQ's capability.
There are methods for combinatorics and sequence analysis, generation and manipulation.<br /><br />

<strong>Combinatorics</strong><br />

Assume we have this string:

```csharp
var source = "abc";
```

We can use the Combine, PartialPermute and Permute methods to obtain the following results:<br />

- Combine

In this example we get combinations of the string "abc" taken at groups of 2 without repetition.
Remember that elements' order doesn't matter, when speaking of combinations.

```csharp
var result = source.Combine(2, GenerateOptions.WithoutRepetition);

Output:
ab
ac
bc
```
<br />

- PartialPermute

In this example we get partial permutations of the string "abc" taken at groups of 2 without repetition.
In this case order does matter.

```csharp
var result = source.PartialPermute(2, GenerateOptions.WithoutRepetition);

Output:
ab
ac
ba
ca
cb
```
<br />

- Permute

In this example we get permutations of the string "abc" without repetition.

```csharp
var result = source.Permute(GenerateOptions.WithoutRepetition);

Output:
abc
acb
bac
cab
cba
```
<br /><br />

<strong>Sequence Generation</strong><br />

- Fibonacci

This method generates Fibonacci numbers between the specified lower and upper limits.
In this example we generate Fibonacci numbers between 10 and 1000:

```csharp

var fibonacci = SequenceGeneration.Fibonacci(10, 1000);

Output:
13
21
34
55
89
144
233
377
610
987
```
<br /><br />

<strong>Others IEnumerable<T> extensions</strong><br />

- RandomOrDefault<br />

As you can expect, this method returns a random element from a list or default(T) if the list is empty.

- Shuffle<br />

This method returns the same list with elements' order randomized.

- TakeRandom<br />

Works as Take but the elements are taken randomly instead of orderly.

- TakeRandomWhile<br />

Same here, works as TakeWhile but elements are taken randomly instead of orderly.
