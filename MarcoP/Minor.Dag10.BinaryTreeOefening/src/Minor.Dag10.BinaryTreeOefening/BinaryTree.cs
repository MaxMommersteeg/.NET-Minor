using System;

namespace Minor.Dag10.BinaryTreeOefening
{
    public abstract class BinaryTree<T>
        where T : IComparable<T>
    {
        public static BinaryTree<T> Empty = new Empty<T>();

        public abstract int Count { get; }
        public abstract int Depth { get; }

        public abstract BinaryTree<T> Add(T item);
    }
}