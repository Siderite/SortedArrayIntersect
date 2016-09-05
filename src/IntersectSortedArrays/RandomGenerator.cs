using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectSortedArrays
{
    /// <summary>
    /// Generates two random arrays of length m and n (if m is larger than n, the values will be switched)
    /// The Spikes parameter adds a number of random ranges filled with random numbers to break the uniform distribution of a normal Random.
    /// </summary>
    public class RandomGenerator:IGenerator
    {
        private int _m;
        private int _n;

        public RandomGenerator(int m, int n)
        {
            _m = Math.Min(m, n);
            _n = Math.Max(m, n);
        }

        public int Spikes
        {
            get;
            set;
        }

        public IList<int> Array1
        {
            get;
            private set;
        }

        public IList<int> Array2
        {
            get;
            private set;
        }

        public void Generate()
        {
            Array1 = generateArray(_m);
            Array2 = generateArray(_n);
        }

        private List<int> generateArray(int length)
        {
            var rnd = new Random();
            var l = length / (Spikes + 1);
            var list = new List<int>();
            for (var i = 0; i < Spikes; i++)
            {
                var start = rnd.Next();
                var end = rnd.Next();
                if (start>end)
                {
                    var t = end;
                    end = start;
                    start = t;
                }
                list.AddRange(Enumerable.Range(0, l).Select(_ => rnd.Next(start,end+1)));
            }
            while (list.Count<length)
            {
                list.Add(rnd.Next());
            }
            list.Sort();
            return list;
        }
    }
}