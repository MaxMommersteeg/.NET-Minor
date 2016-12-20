using System;

namespace Collecties
{
    public abstract class BinaryTree<T> where T : IComparable<T>
    {
        public static BinaryTree<T> Empty = new Empty<T>();
        public int Depth { get; set; }
        public virtual int Count { get; protected set; }

        public abstract BinaryTree<T> Add(T i);
    }
}
