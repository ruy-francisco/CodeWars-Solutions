namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Linq;
    using System.Collections.Generic;

    public class InsertionSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            List<int> subList = new List<int>();
            int currentGreater = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input.ElementAt(i - 1) > input.ElementAt(i))
                {
                    currentGreater = input[i - 1];
                    input[i - 1] = input[i];
                    input[i] = currentGreater;

                    if (i > 1)
                    {
                        int swapped = 0;

                        for (int j = 1; j <= i - 1; j++)
                        {
                            if (input.ElementAt(j) < input.ElementAt(j - 1))
                            {
                                currentGreater = input[j - 1];
                                input[j - 1] = input[j];
                                input[j] = currentGreater;
                                swapped++;
                            }

                            if ((j == i - 1) && swapped > 0)
                            {
                                swapped = 0;
                                j = 0;
                                continue;
                            }
                        }
                    }
                    
                }
            }

            return input;
        }
    }
}
