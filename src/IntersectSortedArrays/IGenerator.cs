using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Generates two arrays of integer
    /// </summary>
    public interface IGenerator
    {
        void Generate();

        IList<int> Array1 { get; }
        IList<int> Array2 { get; }
    }
}
