using System;

namespace Collecties
{
    internal class Branch<T> : BinaryTree<T> where T : IComparable<T>
    {
        public T Item { get; set; }

        private BinaryTree<T> _right;
        private BinaryTree<T> _left;

        public override int Count
        {
            get
            {
                return 1 + _right.Count + _left.Count;
            }
        }

        /// <summary>
        /// Creates a new branch
        /// Set current Item for branch
        /// Set right and left to new empty
        /// </summary>
        /// <param name="value"></param>
        public Branch(T value)
        {
            Item = value;
            _right = Empty;
            _left = Empty;
        }

        public override BinaryTree<T> Add(T i)
        {      
            // Check if we need to insert left
            if (Item.CompareTo(i) < 0)
            {
                if (_left is Empty<T>)
                {
                    _left = new Branch<T>(i);
                    Count++;
                    return this;
                }
                else
                {
                    return _left.Add(i);
                }
            }

            // Check if we have the same value then current one
            if(i.Equals(Item))
            {
                return this;
            }

            // Check if we need to insert right
            if (Item.CompareTo(i) > 0)
            {
                if (_right is Empty<T>)
                {
                    _right = new Branch<T>(i);
                    Count++;
                    return this;
                }
                else
                {
                    return _right.Add(i);
                }
            }

            throw new ArgumentException();
        }
    }
}
