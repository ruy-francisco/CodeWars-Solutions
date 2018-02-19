namespace DesignPattern_Strategy
{
    using DesignPattern_Strategy.Classes;
    using DesignPattern_Strategy.Interfaces;
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = GenerateRandomList(100);

            Console.WriteLine("Bellow it's possible to see many ways to sort an array");
            Console.WriteLine();

            Console.WriteLine("Bubble Sort");
            UseSort(input, new BubbleSort());

            Console.WriteLine("Insertion Sort");
            UseSort(input, new InsertionSort());

            Console.WriteLine("Merge Sort");
            UseSort(input, new MergeSort());

            Console.WriteLine("Shell Sort");
            UseSort(input, new ShellSort());

            Console.WriteLine("Selection Sort");
            UseSort(input, new SelectionSort());

            Console.WriteLine("Quick Sort");
            UseSort(input, new QuickSort());

            Console.ReadKey();
        }

        private static void UseSort(List<int> input, ISorter<int> sorter)
        {
            List<int> inputToBeSorted = input;

            Stopwatch watch = Stopwatch.StartNew();
            List<int> sortedArray = sorter.Sort(inputToBeSorted);
            watch.Stop();

            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < input.Count; i++)
                Console.Write(sortedArray[i] + " ");

            Console.WriteLine();
            Console.WriteLine("Elapsed time in milliseconds: {0}", watch.ElapsedMilliseconds);
            Console.WriteLine();
        }

        private static List<int> GenerateRandomList(int numberOfElements)
        {
            Random random = new Random();
            int randomNumber = 0;

            HashSet<int> hashSet = new HashSet<int>();

            while (hashSet.Count < numberOfElements)
            {
                randomNumber = random.Next(0, numberOfElements);
                hashSet.Add(randomNumber);
            }

            return hashSet.ToList();
        }
    }
}
