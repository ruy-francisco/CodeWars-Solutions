using BinarySearch.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearch.Class
{
    public static class BinarySearch
    {
        public static int GetIndexForValue<T>(this IEnumerable<T> orderedSequence, T valueToSearch)
            where T: IComparable
        {
            int bigestIndex = orderedSequence.Count() - 1;
            int smallestIndex = 0;
            int middle = 0;

            if (smallestIndex > bigestIndex)
                throw new Exception("Something got wrong");

            while (smallestIndex <= bigestIndex)
            {
                middle = (int)Math.Floor((decimal)(bigestIndex + smallestIndex) / 2);

                if (orderedSequence.ElementAt(middle).CompareTo(valueToSearch) < 0)
                {
                    smallestIndex = middle + 1;
                    continue;
                }

                if (orderedSequence.ElementAt(middle).CompareTo(valueToSearch) > 0)
                {
                    bigestIndex = middle - 1;
                    continue;
                }

                return middle;
            }

            throw new ValueNotFoundException("Valor não encontrado");
        }
    }
}
