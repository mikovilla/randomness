using randomness.Application;
using System.Diagnostics;

int runs = 100;
int size = 1_000_000;
int randomIntensity = 1;

if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
{
    runs = int.Parse(args[0]);
}

if (args.Length > 1 && !string.IsNullOrWhiteSpace(args[1]))
{
    size = int.Parse(args[1]);
}
if (args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]))
{
    randomIntensity = int.Parse(args[2]);
}

Console.WriteLine("Preparing to benchmark...");
Console.WriteLine($"Number of runs: {runs}");
Console.WriteLine($"Number of size: {size}");
Console.WriteLine($"Randomness Intensity: {size * randomIntensity}");

Stopwatch stopwatch = Stopwatch.StartNew();
int[] arr = QuickSortComparison.GenerateRandomArray(size, randomIntensity);

// Create copies for fair comparison between sorting methods
int[] copy1 = (int[])arr.Clone();
int[] copy2 = (int[])arr.Clone();

double[] detTimes = new double[runs];
double[] randTimes = new double[runs];

long[] testNumbers = { 1000003, 1000033, 1000197, 1000433 };
Console.WriteLine($"In the meantime checkout this MonteCarloPrimality function that determines whether the following numbers are prime or composite numbers: {string.Join(", ", testNumbers)}");
foreach (long num in testNumbers)
{
    Console.WriteLine($"{num} is {(MonteCarloPrimality.IsProbablyPrime(num) ? "prime" : "composite")}");
}

Console.WriteLine("Running benchmark...");
// Measure and compare execution time of deterministic and randomized QuickSort
for (int i = 0; i < runs; i++)
{
    detTimes[i] = QuickSortComparison.MeasureSortPerformance(copy1, "Deterministic QuickSort", QuickSortComparison.DeterministicQuickSort);
    randTimes[i] = QuickSortComparison.MeasureSortPerformance(copy2, "Randomized QuickSort", QuickSortComparison.RandomizedQuickSort);
}

QuickSortComparison.SaveResults("/data/runtime_results.csv", detTimes, randTimes);
Console.WriteLine($"Randomness Factor runs for {stopwatch.ElapsedMilliseconds} ms.");
