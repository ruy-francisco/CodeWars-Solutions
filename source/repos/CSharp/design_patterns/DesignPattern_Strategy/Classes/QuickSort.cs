namespace DesignPattern_Strategy.Classes
{
    using DesignPattern_Strategy.Interfaces;
    using System.Collections.Generic;

    public class QuickSort : ISorter<int>
    {
        public List<int> Sort(List<int> input)
        {
            DoTheQuickSort(0, input.Count - 1, input);
            return input;
        }

        private void DoTheQuickSort(int left, int right, IList<int> input)
        {
            if (right - left <= 0)
                return;

            int pivot = input[right];
            int partition = MakePartitition(left, right, pivot, input);
            DoTheQuickSort(left, partition - 1, input);
            DoTheQuickSort(partition + 1, right, input);
        }

        private int MakePartitition(int left, int right, int pivot, IList<int> input)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while (true)
            {
                while (input[++leftPointer] < pivot){}

                while (rightPointer > 0 && input[--rightPointer] > pivot){}

                if (leftPointer >= rightPointer)
                    break;

                int innerValueAtLeft = input[leftPointer];
                input[leftPointer] = input[rightPointer];
                input[rightPointer] = innerValueAtLeft;
            }

            int valueAtLeft = input[leftPointer];
            input[leftPointer] = input[right];
            input[right] = valueAtLeft;

            return leftPointer;
        }
    }
}
