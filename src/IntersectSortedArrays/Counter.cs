using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Simple counter implementation
    /// </summary>
    public class Counter : ICounter
    {
        public int Count
        {
            get;
            private set;
        }

        public ICounter Add(int value)
        {
            Count += value;
            return this;
        }

        public ICounter Reset()
        {
            Count = 0;
            return this;
        }
    }
}
