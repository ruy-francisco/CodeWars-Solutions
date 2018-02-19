namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Collections.Generic;

    public class SelectionSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            int lowestNumber = 0;
            int lowestIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                lowestNumber = input[i];

                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[j] < lowestNumber)
                    {
                        lowestNumber = input[j];
                        lowestIndex = input.IndexOf(lowestNumber);
                    }
                }

                if (lowestNumber != input[i])
                {
                    input[lowestIndex] = input[i];
                    input[i] = lowestNumber;
                }
            }

            return input;
        }
    }
}
