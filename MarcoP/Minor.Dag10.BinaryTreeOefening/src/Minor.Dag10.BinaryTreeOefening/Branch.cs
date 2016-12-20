using System;

namespace Minor.Dag10.BinaryTreeOefening
{
    internal class Branch<T> : BinaryTree<T>
        where T: IComparable<T>
    {
        private T _item;
        private BinaryTree<T> _left;
        private BinaryTree<T> _right;

        public Branch(T item) 
        {
            _item = item;
            _left = BinaryTree<T>.Empty;
            _right = BinaryTree<T>.Empty;
        }

        public override int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Depth
        {
            get { return 1 + Math.Max(_left.Depth,_right.Depth); }
        }

        public override BinaryTree<T> Add(T item)
        {
            var compare = item.CompareTo(_item);
            if (compare < 0)    //  item < _item
            {
                _left = _left.Add(item);
            }
            else if(compare > 0)    //  item > _item
            {
                _right = _right.Add(item);
            }

            return this;
        }
    }
}