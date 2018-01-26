namespace DesignPattern_Strategy
{
    using DesignPattern_Strategy.Classes;
    using DesignPattern_Strategy.Interfaces;
    using System;
    using System.Linq;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 4, 54, 1, 22 , 12, 11, 15, 2, 53 };

            var watcher = Stopwatch.StartNew();
            UserSort(input, new InsertionSort());
            watcher.Stop();
            var insertionSortElapsedMilliseconds = watcher.ElapsedMilliseconds;

            Console.WriteLine();

            watcher.Restart();
            UserSort(input, new BubbleSort());
            watcher.Stop();
            var bubbleSortElapsedMilliseconds = watcher.ElapsedMilliseconds;

            Console.WriteLine();

            watcher.Restart();
            UserSort(input, new SelectionSort());
            watcher.Stop();
            var selectionSortElapsedMilliseconds = watcher.ElapsedMilliseconds;

            Console.WriteLine();
            Console.WriteLine("Insertion sort elapsed time: {0}", insertionSortElapsedMilliseconds);
            Console.WriteLine("bubble sort elapsed time: {0}", bubbleSortElapsedMilliseconds);
            Console.WriteLine("Selection sort elapsed time: {0}", selectionSortElapsedMilliseconds);

            Console.ReadKey();
        }

        private static void UserSort(int[] input, ISorter<int> sorter)
        {
            int[] inputToBeSorted = input;
            int[] sortedArray = sorter.Sort(inputToBeSorted.ToList()).ToArray();

            for (int i = 0; i < input.Count(); i++)
                Console.Write(sortedArray[i] + " ");
        }
    }
}
