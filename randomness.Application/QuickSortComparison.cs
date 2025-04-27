using System.Diagnostics;

namespace randomness.Application
{
    public static class QuickSortComparison
    {
        // Generates an array of specified size filled with random integers
        public static int[] GenerateRandomArray(int size, int randomIntensity = 1)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                // Random numbers between 1 and (size * how intense the randomNumber should be)
                arr[i] = rand.Next(1, size * randomIntensity); // (e.g., array with size 4 with randomIntensity set to 2 can have values with any number of 1-8

            return arr;
        }

        // Measures the sorting time of a given algorithm
        public static double MeasureSortPerformance(int[] arr, string label, Action<int[], int, int> sortMethod)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Execute the sorting method
            sortMethod(arr, 0, arr.Length - 1);

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void SaveResults(string fileName, double[] detTimes, double[] randTimes)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Run,Deterministic QuickSort,Randomized QuickSort");
                for (int i = 0; i < detTimes.Length; i++)
                {
                    writer.WriteLine($"{i + 1},{detTimes[i]},{randTimes[i]}");
                }
            }
        }

        // Deterministic QuickSort with pivot always as the first element
        public static void DeterministicQuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = left; // Fixed pivot at the start
                int partitionIndex = Partition(arr, left, right, pivotIndex);

                // Recursively sort elements before and after partition
                DeterministicQuickSort(arr, left, partitionIndex - 1);
                DeterministicQuickSort(arr, partitionIndex + 1, right);
            }
        }

        // Randomized QuickSort with pivot selected randomly
        public static void RandomizedQuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                Random rand = new Random();
                int pivotIndex = rand.Next(left, right + 1); // Randomly select pivot index
                int partitionIndex = Partition(arr, left, right, pivotIndex);

                // Recursively sort elements before and after partition
                RandomizedQuickSort(arr, left, partitionIndex - 1);
                RandomizedQuickSort(arr, partitionIndex + 1, right);
            }
        }

        // Partitions the array based on the selected pivot
        public static int Partition(int[] arr, int left, int right, int pivotIndex)
        {
            int pivotValue = arr[pivotIndex]; // Pivot element
            Swap(arr, pivotIndex, right); // Move pivot to end
            int storeIndex = left;

            // Rearrange elements based on pivot value
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivotValue)
                {
                    Swap(arr, i, storeIndex);
                    storeIndex++;
                }
            }

            // Move pivot to its final position
            Swap(arr, storeIndex, right);
            return storeIndex;
        }

        // Swaps two elements in the array
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
