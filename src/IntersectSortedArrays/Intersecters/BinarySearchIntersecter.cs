using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectSortedArrays
{
    /// <summary>
    /// It performs binary searches to find values, rather than linear ones.
    /// Helpful when the first array is much smaller than the other
    /// </summary>
    public class BinarySearchIntersecter : IntersecterBase
    {
        public BinarySearchIntersecter(ICounter counter):base(counter)
        {
        }

        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            var p1 = 0;
            var p2 = 0;
            var result = new List<int>();
            while (p1 < arr1.Count && p2 < arr2.Count)
            {
                var v1 = arr1[p1];
                var v2 = arr2[p2];
                _counter.Add(1);
                switch (v1.CompareTo(v2))
                {
                    case -1:
                        p1=binarySearch(arr1,p1+1,v2);
                        break;
                    case 0:
                        result.Add(v1);
                        p1++;
                        p2++;
                        break;
                    case 1:
                        p2 = binarySearch(arr2,p2+1, v1);
                        break;
                }
            }
            return result;
        }

        private int binarySearch(IList<int> arr, int p, int v)
        {
            return Util.BinarySearch(arr, p, v,_counter);
        }
    }
}