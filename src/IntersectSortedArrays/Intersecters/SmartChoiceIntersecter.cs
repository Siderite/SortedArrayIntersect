using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// if the first array is sufficiently small compared to the second, binary search will be used, otherwise linear one.
    /// </summary>
    public class SmartChoiceIntersecter : IntersecterBase
    {
        public SmartChoiceIntersecter(ICounter counter) : base(counter)
        {
        }


        protected override IList<int> DoIntersect(IList<int> arr1, IList<int> arr2)
        {
            IIntersecter intersecter;
            if (arr1.Count*Math.Ceiling(Math.Log(arr2.Count))<arr1.Count+arr2.Count)
            {
                intersecter = new BinarySearchIntersecter(_counter);
            } else
            {
                intersecter = new StandardIntersecter(_counter);
            }
            intersecter.Intersect(arr1, arr2);
            return intersecter.Result;
        }
    }
}
