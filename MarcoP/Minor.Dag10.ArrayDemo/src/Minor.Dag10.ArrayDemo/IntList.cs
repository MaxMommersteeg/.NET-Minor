using System;
using System.Collections;
using System.Collections.Generic;

namespace Minor.Dag10.ArrayDemo.Test
{
    public class List<T> : IEnumerable<T>
        where T : IComparable<T>
        //        where T : class    t is reference type
        //        where T : struct   t is value type
        //where T : IComparable<T>, IEquatable<T>
    {
        private T[] _items;
        public int Count { get; private set; }

        public List(int capacity = 4)
        {
            _items = new T[capacity];
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count >= _items.Length)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[Count] = item;
            Count++;
        }

        // indexer
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public void Sort()
        {
            T first = _items[0];
            T second = _items[1];
            if (second.CompareTo(first) < 0)
            {
                _items[0] = second;
                _items[1] = first;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //int i = Count;
            //while (i --> 0)
            for(int i=0; i<Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}