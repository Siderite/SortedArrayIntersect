using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// A counter can only be added to and be reset.
    /// Provides a fluent interface
    /// </summary>
    public interface ICounter
    {
        int Count { get; }

        ICounter Reset();

        ICounter Add(int value);
    }
}
