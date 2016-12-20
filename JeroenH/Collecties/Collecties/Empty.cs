using System;

namespace Collecties
{
   
    public class Empty<T> : BinaryTree<T>
         where T : IComparable<T>
    {
        public override int Count { get; } = 0;

        public override int Depth { get;} = 0;



    }
}