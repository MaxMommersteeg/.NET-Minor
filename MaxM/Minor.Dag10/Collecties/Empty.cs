using System;

namespace Collecties
{
    internal class Empty<T> : BinaryTree<T> where T : IComparable<T>
    {
        public override BinaryTree<T> Add(T i)
        {
            return new Branch<T>(i);
        }
    }
}
