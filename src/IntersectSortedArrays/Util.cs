using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    public static class Util
    {
        /// <summary>
        /// Performs a binary search on a sorted list, from a specified position
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="p"></param>
        /// <param name="v"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public static int BinarySearch(IList<int> arr, int p, int v, ICounter counter)
        {
            var start = p;
            var end = arr.Count - 1;
            if (start > end) return start;
            while (true)
            {
                var mid = (start + end) / 2;
                var val = arr[mid];
                if (mid == start)
                {
                    counter.Add(1);
                    return val < v ? mid + 1 : mid;
                }
                counter.Add(1);
                switch (val.CompareTo(v))
                {
                    case -1:
                        start = mid + 1;
                        break;
                    case 0:
                        return mid;
                    case 1:
                        end = mid - 1;
                        break;
                }
            }
        }
    }
}
