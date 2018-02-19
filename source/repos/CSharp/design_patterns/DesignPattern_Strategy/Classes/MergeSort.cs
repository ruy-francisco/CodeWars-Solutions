namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            if (input.Count == 1)
                return input;

            int[] firstPart = input.Take(input.Count / 2).ToArray();
            int[] secondPart = input.Skip(input.Count / 2).ToArray();

            firstPart = Sort(firstPart.ToList()).ToArray();
            secondPart = Sort(secondPart.ToList()).ToArray();

            return MergeArrays(firstPart, secondPart);
        }

        private List<int> MergeArrays(int[] firstPart, int[] secondPart)
        {
            List<int> firstPartList = firstPart.ToList();
            List<int> secondPartList = secondPart.ToList();
            List<int> mergedList = new List<int>();

            while (firstPartList.Count > 0 && secondPartList.Count > 0)
            {
                if (firstPartList[0] > secondPartList[0])
                {
                    mergedList.Add(secondPartList[0]);
                    secondPartList.RemoveAt(0);
                    continue;
                }

                mergedList.Add(firstPartList[0]);
                firstPartList.RemoveAt(0);
            }

            while (firstPartList.Count > 0)
            {
                mergedList.Add(firstPartList[0]);
                firstPartList.RemoveAt(0);
            }

            while (secondPartList.Count > 0)
            {
                mergedList.Add(secondPartList[0]);
                secondPartList.RemoveAt(0);
            }

            return mergedList;
        }
    }
}
