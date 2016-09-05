using System;
using System.Collections.Generic;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Instead of comparing values one by one, it tries to compare them in pairs.
    /// For certain distributions that eliminates some comparisons
    /// </summary>
    public class PairSearchIntersecter : IntersecterBase
    {
        public PairSearchIntersecter(ICounter counter):base(counter)
        {
        }

        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            var p1 = 0;
            var p2 = 0;
            var result = new List<int>();
            while (p1 < arr1.Count-1 && p2 < arr2.Count-1)
            {
                var v1a = arr1[p1];
                var v2a = arr2[p2];
                var v1b = arr1[p1+1];
                var v2b = arr2[p2+1];
                _counter.Add(1);
                switch (v1a.CompareTo(v2b))
                {
                    case -1:
                        {
                            _counter.Add(1);
                            switch (v1b.CompareTo(v2a))
                            {
                                case -1:
                                    p1 += 2;
                                    break;
                                case 0:
                                    result.Add(v1b);
                                    p2++;
                                    p1 += 2;
                                    break;
                                case 1:
                                    _counter.Add(1);
                                    if (v1a==v2a)
                                    {
                                        result.Add(v1a);
                                    }
                                    p1++;
                                    p2++;
                                    break;
                            }
                        }
                        break;
                    case 0:
                        result.Add(v1a);
                        p1++;
                        p2+=2;
                        break;
                    case 1:
                        p2+=2;
                        break;
                }
            }
            if (p1 == arr1.Count - 1)
            {
                var v1 = arr1[p1];
                var i = binarySearch(arr2, p2, v1);
                if (i < arr2.Count && v1 == arr2[i]) result.Add(v1);
            }
            if (p2 == arr2.Count - 1)
            {
                var v2 = arr2[p2];
                var i = binarySearch(arr1, p1, v2);
                if (i < arr1.Count && v2 == arr1[i]) result.Add(v2);
            }
            return result;
        }

        private int binarySearch(IList<int> arr, int p, int v)
        {
            return Util.BinarySearch(arr, p, v,_counter);
        }

    }
}