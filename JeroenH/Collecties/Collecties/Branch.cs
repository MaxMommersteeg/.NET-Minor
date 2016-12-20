using Collecties;
using System;
using System.Collections.Generic;
using System.Collections;

public class Branch<T> :  BinaryTree<T>, IEnumerable<T>
    where T : IComparable<T>
    
{

    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }

    public T Value { get; set; }

    public override int Count { 
        get
        {
            return 1 + LeftChild.Count + RightChild.Count;
        }

    }

    public override int Depth {
        get
        {
            return 1 + Math.Max(LeftChild.Depth, RightChild.Depth);
        }
        

    }

    public Branch(T value)
    {
        Value = value;
        LeftChild = new Empty<T>();
        RightChild = new Empty<T>();
    }

    public override BinaryTree<T> Add(T value)
    {
        if (value.CompareTo(Value) == -1)
        {
            if (LeftChild.GetType() == typeof(Branch<T>))
            {
                LeftChild.Add(value);
            }
            else
            {
                Branch<T> tempBranch = new Branch<T>(value);
                LeftChild = tempBranch;
            }

        }
        else if (value.CompareTo(Value) == 1)
        {
            if (RightChild.GetType() == typeof(Branch<T>))
            {
                RightChild.Add(value);
            }
            else
            {
                Branch<T> tempBranch = new Branch<T>(value);
                RightChild = tempBranch;
            }

        }
        return this;
    }

    public override bool Contains(T item)
    {
        if (item.CompareTo(Value)==0)
        {
            return true;
        }
        else if (LeftChild.GetType() == typeof(Branch<T>) || RightChild.GetType() == typeof(Branch<T>))
        {
            if (item.CompareTo(Value) == -1)
            {
                return LeftChild.Contains(item);
            }
            else
            {
                return RightChild.Contains(item);
            }
        }
        else
        {
            return false;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {

        if (LeftChild.GetType() == typeof(Branch<T>))
        {
            foreach (var child in (Branch<T>)LeftChild)
            {
                yield return child;
            }
        }
        yield return Value;
        if (RightChild.GetType() == typeof(Branch<T>))
        {
            foreach (var child in (Branch<T>)RightChild)
            {
                yield return child;
            }
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }
}