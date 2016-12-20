using FrontEnd.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FrontEnd.MVC.Test.Extensions
{
    [TestClass]
    public class ListExtensionsTest
    {
        [TestMethod]
        public void ChunkByIntTest()
        {
            // Arrange
            var chunkSize = 100;
            var list = Enumerable.Range(0, 2000).ToList();

            // Act
            var result = list.ChunkBy(chunkSize);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(20, result.Count);
            Assert.AreEqual(result.First().Count, 100);
            Assert.AreEqual(result.Last().Count, 100);
        }

        [TestMethod]
        public void ChunkByIntHalfFullChunkTest()
        {
            // Arrange
            var chunkSize = 25;
            var list = Enumerable.Range(0, 99).ToList();

            // Act
            var result = list.ChunkBy(chunkSize);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(25, result.First().Count);
            Assert.AreEqual(24, result.Last().Count);
        }

        [TestMethod]
        public void ChunkByStringCorrectContentsTest()
        {
            // Arrange
            var chunkSize = 1;
            var list = new List<string>() { "een", "twee", "drie", "vier", "vijf" };

            // Act
            var result = list.ChunkBy(chunkSize);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("een", result.First().First());
            Assert.AreEqual("een", result.First().Last());
            Assert.AreEqual("vijf", result.Last().First());
            Assert.AreEqual("vijf", result.Last().Last());
        }
    }
}
