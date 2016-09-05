using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Linear search, but starting from the end of the arrays
    /// </summary>
    public class ReverseIntersecter:IntersecterBase
    {
        public ReverseIntersecter(ICounter counter):base(counter)
        {
        }

        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            var p1 = arr1.Count - 1;
            var p2 = arr2.Count - 1;
            var result = new List<int>();
            while (p1 >= 0 && p2 >= 0)
            {
                var v1 = arr1[p1];
                var v2 = arr2[p2];
                _counter.Add(1);
                switch (v1.CompareTo(v2))
                {
                    case -1:
                        p2--;
                        break;
                    case 0:
                        result.Add(v1);
                        p1--;
                        p2--;
                        break;
                    case 1:
                        p1--;
                        break;
                }
            }
            return result;
        }
    }
}