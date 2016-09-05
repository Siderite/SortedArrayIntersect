using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectSortedArrays
{
    /// <summary>
    /// It looks for the middle value of an array in the other using binary search only once
    /// then uses linear search and reverse linear search from the found points
    /// </summary>
    public class MiddleOutIntersecter : IntersecterBase
    {
        public MiddleOutIntersecter(ICounter counter):base(counter)
        {
            _intersecter1 = new ReverseIntersecter(counter);
            _intersecter2 = new StandardIntersecter(counter);
        }

        private IIntersecter _intersecter1;
        private IIntersecter _intersecter2;

        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            var halfM = arr1.Count / 2;
            var v1 = arr1[halfM];
            var halfN = binarySearch(arr2, v1);
            _intersecter1.Intersect(new PartialList<int>(arr1, 0, halfM), new PartialList<int>(arr2, 0, halfN));
            _intersecter2.Intersect(new PartialList<int>(arr1, halfM), new PartialList<int>(arr2, halfN));
            Time = _intersecter1.Time + _intersecter2.Time;
            return _intersecter1.Result.Concat(_intersecter2.Result).ToList();
        }

        private int binarySearch(IList<int> arr, int v)
        {
            return Util.BinarySearch(arr, 0, v, _counter);
        }
    }
}