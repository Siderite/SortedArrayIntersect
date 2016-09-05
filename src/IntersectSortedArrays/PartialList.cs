using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntersectSortedArrays
{
    /// <summary>
    /// A readonly IList&lt;T&gt; implementation that represents a section of an existing list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PartialList<T>:IList<T>
    {
        private int _count;
        private IList<T> _list;
        private int _start;

        public PartialList(IList<T> list,int start, int count=int.MaxValue)
        {
            _list = list;
            _start = Math.Max(0,start);
            _count = Math.Min(count,list.Count-start);
        }

        public T this[int index]
        {
            get
            {
                return _list[index + _start];
            }

            set
            {
                _list[index + _start] = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return IndexOf(item)>-1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (var i=0; i<Count && i<array.Length-arrayIndex; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i=0; i<Count; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (item.Equals(this[i])) return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
