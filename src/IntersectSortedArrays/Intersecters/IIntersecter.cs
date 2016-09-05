using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    public interface IIntersecter
    {
        void Intersect(IList<int> arr1, IList<int> arr2);

        int Comparisons { get; }

        TimeSpan Time { get; }

        IList<int> Result { get; }
    }
}
