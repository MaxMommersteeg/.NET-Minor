using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collecties.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeEmptyBestaat()
        {
            // Arrange - Act
            var target = BinaryTree<int>.Empty;

            // Assert
            Assert.IsTrue(target != null);
        }

        [TestMethod]
        public void BinaryTreeEmptyJuisteType()
        {
            // Arrange - Act
            var target = BinaryTree<int>.Empty;

            // Assert
            Assert.IsTrue(target != null);
            Assert.IsTrue(target is BinaryTree<int>);
        }

        [TestMethod]
        public void BinaryTreeAdd1Klopt()
        {
            // Arrange
            var target = BinaryTree<int>.Empty;

            // Act
            target = target.Add(10);

            // Assert
            Assert.AreEqual(1, target.Count);
        }

        [TestMethod]
        public void BinaryTreeAdd2Klopt()
        {
            // Arrange
            var target = BinaryTree<int>.Empty;

            // Act
            target = target.Add(10);
            target = target.Add(30);

            // Assert
            Assert.AreEqual(2, target.Count);
        }

        [TestMethod]
        public void BinaryTreeCount3KloptNiet()
        {
            // Arrange
            var target = BinaryTree<int>.Empty;

            // Act
            target = target.Add(10);
            target = target.Add(30);
            target = target.Add(30);

            // Assert
            Assert.AreEqual(2, target.Count);
        }

        [TestMethod]
        public void BinaryTreeCount5Klopt()
        {
            // Arrange
            var target = BinaryTree<int>.Empty;

            // Act
            target = target.Add(10);
            target = target.Add(30);
            target = target.Add(45);
            target = target.Add(11);
            target = target.Add(13);

            // Assert
            Assert.AreEqual(5, target.Count);
        }
    }
}
