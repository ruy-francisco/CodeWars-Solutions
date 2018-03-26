using System;
using System.Collections.Generic;
using BinarySearch.Class;
using BinarySearch.CustomExceptions;

namespace BinarySearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 56, 78, 79, 100 };
                List<string> names = new List<string> { "Carlos", "Fernando", "Fúlvia", "Fred", "Ruy", "Zelda" };

                int numberToSearch = 0;

                Console.Write("Digite um número para ser procurado: ");
                string typedNumbers = Console.ReadLine();

                int.TryParse(typedNumbers, out numberToSearch);

                Console.WriteLine("O índice do número procurado é: {0}", numbers.GetIndexForValue(numberToSearch));

                Console.Write("Digite um nome para ser procurado: ");
                string typedName = Console.ReadLine();
                Console.WriteLine("O índice do número procurado é: {0}", names.GetIndexForValue(typedName));

                Console.ReadKey();
            }
            catch (ValueNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
