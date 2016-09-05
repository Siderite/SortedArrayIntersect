using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Base class for Intersecters
    /// </summary>
    public abstract class IntersecterBase : IIntersecter
    {
        protected ICounter _counter;

        public IntersecterBase(ICounter counter)
        {
            _counter = counter;
        }

        public int Comparisons
        {
            get { return _counter.Count; }
        }

        public TimeSpan Time
        {
            get;
            protected set;
        }

        public IList<int> Result
        {
            get;
            protected set;
        }

        public void Intersect(IList<int> arr1, IList<int> arr2)
        {
            var sp = new Stopwatch();
            sp.Start();
            var result = DoIntersect(arr1, arr2);
            sp.Stop();
            Time = sp.Elapsed;
            Result=result;
        }

        protected abstract IList<int> DoIntersect(IList<int> arr1, IList<int> arr2);
    }
}