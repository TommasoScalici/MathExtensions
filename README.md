# LINQ Extensions

LINQ extensions for .NET is a collection of useful extensions methods that extends LINQ's capability.
There are methods for combinatorics and sequence analysis, generation and manipulation.<br /><br />

### Combinatorics<br />

Assume we have this string:

```csharp
var source = "abc";
```

We can use the Combine, PartialPermute and Permute methods to obtain the following results:<br /><br />

#### Combine

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

#### PartialPermute

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

#### Permute

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

### Sequence Analysis<br />

#### FindSequenceKind

This method analyze a sequence and returns the sequence kind if a pattern is found.

```csharp
var sequenceA = new[] { 2, 4, 6, 8, 10 };
var sequenceB = new[] { 3, 9, 27, 81 };
var thisIsAmbiguous = new[] { 2, 4 };

Console.WriteLine(sequenceA.FindSequenceKind());
Console.WriteLine(sequenceB.FindSequenceKind());
Console.WriteLine(thisIsAmbiguous.FindSequenceKind());

Output:
Arithmetic
Geometric
ArithmeticOrGeometric
```
<br /><br />

### Sequence Generation<br />

#### Arithmetic

This method generates an arithmetic sequence between the specified lower and upper limits, given an additive constant.

```csharp

var arithmeticSequence = SequenceGeneration.Arithmetic(5, 5, 50);

Output:
5
10
15
20
25
30
35
40
45
50
```
<br />

#### Fibonacci

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
<br />

#### Geometric

This method generates a geometric sequence between the specified lower and upper limits, given a multiplicative constant.

```csharp

var geometricSequence = SequenceGeneration.Geometric(2, maxValue: 64);

Output:
1
2
4
8
16
32
64
```
<br />

#### PrimeNumbers

This method generates a prime numbers sequence between the specified lower and upper limits, using a Sieve of Eratosthenes based algorithm.

```csharp

var primeNumbers = SequenceGeneration.PrimeNumbers(maxValue: 50);

Output:
2
3
5
7
11
13
17
19
23
29
31
37
41
43
49
```
<br />

#### Triangular

This method generates a triangular sequence between the specified lower and upper limits.

```csharp

var triangularSequence = SequenceGeneration.Triangular(maxValue: 20);

Output:
1
3
6
10
15
```
<br /><br />

### Others IEnumerable<T> extensions<br />

#### RandomOrDefault<br />

As you can expect, this method returns a random element from a list or default(T) if the list is empty.

#### Shuffle<br />

This method returns the same list with elements' order randomized.

#### TakeRandom<br />

Works as Take but the elements are taken randomly instead of orderly.

#### TakeRandomWhile<br />

Same here, works as TakeWhile but elements are taken randomly instead of orderly.

<br /><br />

## License

LINQ Extensions is released under [MIT License](https://github.com/TommasoScalici/LINQExtensions/blob/master/LICENSE.md).