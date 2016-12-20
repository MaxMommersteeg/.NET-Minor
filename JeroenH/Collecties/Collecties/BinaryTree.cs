using System;


namespace Collecties
{
    public abstract class BinaryTree<T>
        where T : IComparable<T>

    {
        private static Empty<T> Empty { get; set; }

        public virtual  int Count { get;}

        public virtual int Depth { get; }

        public BinaryTree()
        {

        }

        public virtual BinaryTree<T> Add(T value)
        {
            return new Branch<T>(value);
        }

        public virtual bool Contains(T item)
        {
            return false;
        }

    }
}