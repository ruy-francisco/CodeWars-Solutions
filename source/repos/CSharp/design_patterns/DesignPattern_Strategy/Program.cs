namespace DesignPattern_Strategy
{
    using DesignPattern_Strategy.Classes;
    using DesignPattern_Strategy.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 4, 54, 1, 22 , 12, 11, 15, 2, 53 };

            UserSort(input, new InsertionSort());      

            Console.ReadKey();
        }

        private static void UserSort(int[] input, ISorter<int> sorter)
        {
            input = sorter.Sort(input.ToList()).ToArray();

            for (int i = 0; i < input.Count(); i++)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}
