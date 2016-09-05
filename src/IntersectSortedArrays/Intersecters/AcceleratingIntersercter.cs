using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// While looking for a value, it accelerates the search in a direction with each miss
    /// for example if a1[1]&lt;a2[1], the next check will be of a1[1] with a2[3] (not a[2], speed increasing)
    /// </summary>
    public class AcceleratingIntersecter : IntersecterBase
    {
        public AcceleratingIntersecter(ICounter counter):base(counter)
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
                var comp = v1.CompareTo(v2);
                switch (comp)
                {
                    case -1:
                        p1 = acceleratedSearch(arr1, p1, v2);
                        break;
                    case 0:
                        result.Add(v1);
                        p1++;
                        p2++;
                        break;
                    case 1:
                        p2 = acceleratedSearch(arr2, p2, v1);
                        break;
                }
            }
            return result;
        }

        private int acceleratedSearch(IList<int> arr, int p, int v)
        {
            var speed = 1;
            var p2 = p + speed;
            while (p2 < arr.Count )
            {
                _counter.Add(1);
                if (arr[p2] < v)
                {
                    speed++;
                } else
                {
                    if (speed <= 1) break;
                    p2 -= speed;
                    speed=1;
                }
                p2 += speed;
            }
            return p2;
        }
    }
}
