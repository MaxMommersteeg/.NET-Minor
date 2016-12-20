using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collecties;
using System.Diagnostics;

namespace CollectiesTesten
{
    [TestClass]
    public class CollectiesTesten
    {

        [TestMethod]
        public void BinaryTreeAanmaken()
        {
            //Arrange
            BinaryTree<int> tree = new Empty<int>();

            //Act

            //Arrange
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeAanmakenMetBranch()
        {
            //Arrange
            BinaryTree<int> tree = new Empty<int>();

            //Act
            tree = tree.Add(4);

            //Arrange
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeAanmakenMetBranchTypeCheck()
        {
            //Arrange
            BinaryTree<int> tree = new Empty<int>();

            //Act
            tree = tree.Add(4);

            //Arrange
            Assert.IsInstanceOfType(tree, typeof(Branch<int>));
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeAanmakenMetBranchTweeMaal()
        {
            //Arrange
            BinaryTree<int> tree = new Empty<int>();

            //Act
            tree = tree.Add(4);
            tree = tree.Add(3);


            //Arrange
            Assert.IsInstanceOfType(tree, typeof(Branch<int>));
            Assert.AreEqual(2, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeWaardeToevoegen()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(4);

            //Act
            int result = tree.Value;

            //Arrange
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void BinaryTreeWaardeToevoegenTweedeMaalHoger()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(4);

            //Act
            tree.Add(5);

            //Arrange
            Assert.IsInstanceOfType(tree.RightChild, typeof(Branch<int>));
            Assert.AreEqual(5, (tree.RightChild as Branch<int>).Value);
        }

        [TestMethod]
        public void BinaryTreeWaardeToevoegenTweedeMaalLager()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(4);

            //Act
            tree.Add(3);

            //Arrange
            Assert.IsInstanceOfType(tree.LeftChild, typeof(Branch<int>));
            Assert.AreEqual(3, (tree.LeftChild as Branch<int>).Value);
        }

        [TestMethod]
        public void BinaryTreeBranchAbstraction()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(4);

            //Act
            tree.Add(3);

            //Arrange
            Assert.IsInstanceOfType(tree.LeftChild, typeof(Branch<int>));
            Assert.AreEqual(3, (tree.LeftChild as Branch<int>).Value);
        }

        [TestMethod]
        public void BinaryTreeBranchcontainsFirstHit()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(4);

            //Act

            //Arrange
            Assert.IsTrue(tree.Contains(4));
        }

        [TestMethod]
        public void BinaryTreeBranchcontainsFirstHitFail()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act

            //Arrange
            Assert.IsFalse(tree.Contains(4));
        }

        [TestMethod]
        public void BinaryTreeBranchDoesntContrainNumberDeep()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(3);
            tree.Add(7);

            //Arrange
            Assert.IsFalse(tree.Contains(4));
        }

        [TestMethod]
        public void BinaryTreeBranchDoesContrainNumberDeep()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(3);
            tree.Add(7);
            tree.Add(9);
            tree.Add(4);

            //Arrange
            Assert.AreEqual(true, tree.Contains(4));
        }

        [TestMethod]
        public void BinaryTreeBranchCount()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(3);
            tree.Add(7);
            tree.Add(9);
            tree.Add(4);

            //Arrange
            Assert.AreEqual(5, tree.Count);
        }

        [TestMethod]
        public void BinaryTreeBranchDepthReturn()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act

            //Arrange
            Assert.AreEqual(1, tree.Depth);
        }

        [TestMethod]
        public void BinaryTreeBranchDepth2AddsReturn()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(4);



            //Arrange
            Assert.AreEqual(2, tree.Depth);
        }

        [TestMethod]
        public void BinaryTreeBranchDepth5AddsReturn()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            //Arrange
            Assert.AreEqual(5, tree.Depth);
        }

        [TestMethod]
        public void BinaryTreeBranchDepthReturnSplitTree()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);

            //Act
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(6);



            //Arrange
            Assert.AreEqual(5, tree.Depth);
        }

        [TestMethod]
        public void BinaryTreeBranchIEnumerableLoop()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(6);

            int count = 0;
            int[] values = { 1,2,3,4,5, 6 };

            //Assert
            foreach (var item in tree)
            {
                Assert.AreEqual(values[count], item, $"{count} failed");
                count++;
            }
        }

        [TestMethod]
        public void BinaryTreeBranchIEnumerableLowest()
        {
            //Arrange
            Branch<int> tree = new Branch<int>(5);
            tree.Add(4);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(6);

            int[] values = { 5, 4, 3, 2, 1, 6 };
            int min;
            //act
            min = tree.Min();


            //Arrange
            Assert.AreEqual(1, min);
        }


    }
}
