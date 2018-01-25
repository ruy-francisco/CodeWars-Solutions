namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class ResursiveSort : ISorter<int>
    {
        public IList<int> Sort(IList<int> input)
        {
            if (input.Count == 1)
                return input;

            if (input.Count == 2)
            {
                if (input[0] > input[1])
                {
                    int currentGreater = input[0];
                    input[0] = input[1];
                    input[1] = currentGreater;
                    return input;
                }

                return input;
            }

            return Sort(input.Take(input.Count / 2).ToList()).ToArray().Intersect(Sort(input.Skip(input.Count / 2).ToList()).ToArray()).ToList() ;
        }
    }
}
