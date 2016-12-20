using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minor.Dag10.BinaryTreeOefening.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void EmptyTreeHasDepth0()
        {
            BinaryTree<int> t = BinaryTree<int>.Empty;

            int result = t.Depth;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Empty_Add_5_HasDepth_1()
        {
            BinaryTree<int> t = BinaryTree<int>.Empty.Add(5);

            int result = t.Depth;

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Empty_Add_5_Add_3_HasDepth_2()
        {
            BinaryTree<int> t = BinaryTree<int>.Empty.Add(5).Add(3);

            int result = t.Depth;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddItemAlreadyPresentIsIdempotent()
        {
            BinaryTree<int> t = BinaryTree<int>.Empty.Add(5).Add(3).Add(7);

            t = t.Add(3);

            Assert.AreEqual(2, t.Depth);
        }

        [TestMethod]
        public void EmptyHasCount0()
        {
            BinaryTree<string> t = BinaryTree<string>.Empty;

            int result = t.Count;

            Assert.AreEqual(0, result);
        }
    }
}
