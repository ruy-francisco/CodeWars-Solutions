namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Collections.Generic;

    public class ShellSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            int interval = 1;

            while (interval < (input.Count / 3))
            {
                interval = interval * 3 + 1;
            }

            int valueToInsert = 0;
            int inner = 0;

            while (interval > 0)
            {
                for (int outer = interval; outer < input.Count; outer++)
                {
                    valueToInsert = input[outer];
                    inner = outer;

                    while ((inner > interval - 1) && (input[inner - interval] >= valueToInsert))
                    {
                        input[inner] = input[inner - interval];
                        inner -= interval;
                    }

                    input[inner] = valueToInsert;
                }

                interval = (interval - 1) / 3;
            }

            return input;
        }
    }
}
