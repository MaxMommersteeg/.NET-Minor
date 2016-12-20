using System;

namespace Minor.Dag10.BinaryTreeOefening
{
    internal class Empty<T> : BinaryTree<T>
        where T : IComparable<T>
    {
        public override int Count
        {
            get { return 0; }
        }

        public override int Depth
        {
            get { return 0; }
        }

        public override BinaryTree<T> Add(T item)
        {
            return new Branch<T>(item);
        }
    }
}