using System;
using System.Collections.Generic;

namespace IntersectSortedArrays
{
    /// <summary>
    /// It takes the middle value of an array and binary searches for it in the second then splits each array on those points
    /// The process continues for each half with each half
    /// </summary>
    public class DivideEtImperaIntersecter : IntersecterBase
    {
        public DivideEtImperaIntersecter(ICounter counter):base(counter)
        {
        }


        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            var q = new Queue<ArrInfo>();
            q.Enqueue(new ArrInfo
            {
                Index1 = 0,
                Length1 = arr1.Count,
                Index2 = 0,
                Length2 = arr2.Count
            });
            var result = new List<int>();
            while (q.Count > 0)
            {
                result.AddRange(process(arr1, arr2, q));
            }
            return result;
        }

        private IEnumerable<int> process(IList<int> arr1, IList<int> arr2, Queue<ArrInfo> q)
        {
            var list = new List<int>();
            var f = q.Dequeue();
            var m1 = f.Index1 + f.Length1 / 2;
            var v1 = arr1[m1];
            var start = f.Index2;
            var end = f.Index2 + f.Length2 - 1;
            var loop = true;
            int m2;
            while (loop)
            {
                m2 = (start + end) / 2;
                if (start > end)
                {
                    if (f.Length1 > 1)
                    {
                        var nf = new ArrInfo
                        {
                            Index1 = f.Index1,
                            Length1 = m1 - f.Index1,
                            Index2 = f.Index2,
                            Length2 = m2 - f.Index2 + 1
                        };
                        if (nf.Length1 > 0 && nf.Length2 > 0) q.Enqueue(nf);
                        nf = new ArrInfo
                        {
                            Index1 = m1 + 1,
                            Length1 = f.Index1 + f.Length1 - m1 - 1,
                            Index2 = m2,
                            Length2 = f.Index2 + f.Length2 - m2
                        };
                        if (nf.Length1 > 0 && nf.Length2 > 0) q.Enqueue(nf);
                    }
                    break;
                }
                var v2 = arr2[m2];
                _counter.Add(1);
                switch (v1.CompareTo(v2))
                {
                    case -1:
                        end = m2 - 1;
                        break;
                    case 0:
                        list.Add(v1);
                        var nf = new ArrInfo
                        {
                            Index1 = f.Index1,
                            Length1 = m1 - f.Index1,
                            Index2 = f.Index2,
                            Length2 = m2 - f.Index2
                        };
                        if (nf.Length1 > 0 && nf.Length2 > 0) q.Enqueue(nf);
                        nf = new ArrInfo
                        {
                            Index1 = m1 + 1,
                            Length1 = f.Index1 + f.Length1 - m1 - 1,
                            Index2 = m2 + 1,
                            Length2 = f.Index2 + f.Length2 - m2 - 1
                        };
                        if (nf.Length1 > 0 && nf.Length2 > 0) q.Enqueue(nf);

                        loop = false;
                        break;
                    case 1:
                        start = m2 + 1;
                        break;
                }
            }
            return list;
        }

        private class ArrInfo
        {
            public int Index1 { get; set; }
            public int Length1 { get; set; }
            public int Index2 { get; set; }
            public int Length2 { get; set; }

            public override string ToString()
            {
                return $"{Index1},{Length1} {Index2},{Length2}";
            }
        }
    }
}