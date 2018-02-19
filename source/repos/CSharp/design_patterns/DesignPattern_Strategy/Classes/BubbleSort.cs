namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Linq;
    using System.Collections.Generic;

    public class BubbleSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            int currentGreater = 0;
            int swapped = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input.ElementAt(i) < input.ElementAt(i - 1))
                {
                    currentGreater = input[i - 1];
                    input[i - 1] = input[i];
                    input[i] = currentGreater;
                    swapped++;
                }                

                if ((i == input.Count - 1) && swapped > 0)
                {
                    swapped = 0;
                    i = 0;
                    continue;
                }
            }

            return input;
        }
    }
}
