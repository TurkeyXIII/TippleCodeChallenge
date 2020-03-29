using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Utility
{
    public static class Set
    {
        public static int Median(IEnumerable<int> set)
        {
            var sortedSet = set.OrderBy(c => c).ToList();

            bool evenNumberOfCounts = sortedSet.Count % 2 == 0;
            if (evenNumberOfCounts)
            {
                int middleIndex2 = sortedSet.Count / 2;
                int middleIndex1 = middleIndex2 - 1;

                int averageOfMiddleValues = (sortedSet[middleIndex1] + sortedSet[middleIndex2]) / 2; //integer division intentional
                return averageOfMiddleValues;
            }
            else
            {
                int middleIndex = (sortedSet.Count - 1) / 2;
                return sortedSet[middleIndex];
            }
        }
    }
}
