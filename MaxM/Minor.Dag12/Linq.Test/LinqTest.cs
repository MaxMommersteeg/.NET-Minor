using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Test
{
    [TestClass]
    public class LinqTest
    {
        #region Vraag 1

        #region Lambda

        [TestMethod]
        public void EersteVoorletterKlopt()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            Assert.AreEqual('R', result.First());
        }

        [TestMethod]
        public void VoorlettersMetR()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            var differentValues = expectedResult.Except(result).ToList();
            Assert.AreEqual(expectedResult.Count, result.Count());    
        }

        [TestMethod]
        public void VoorlettersMetRContentCheck()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            var differentValues = expectedResult.Except(result).ToList();
            Assert.AreEqual(0, differentValues.Count);
        }

        [TestMethod]
        public void VoorlettersMetRVergelijkInhoud()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }

        #endregion

        #region Comprehension

        [TestMethod]
        public void EersteVoorletterKlopt_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1Comprehension();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            Assert.AreEqual('R', result.First());
        }

        [TestMethod]
        public void VoorlettersMetR_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1Comprehension();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            var differentValues = expectedResult.Except(result).ToList();
            Assert.AreEqual(expectedResult.Count, result.Count());
        }

        [TestMethod]
        public void VoorlettersMetRContentCheck_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1Comprehension();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            var differentValues = expectedResult.Except(result).ToList();
            Assert.AreEqual(0, differentValues.Count);
        }

        [TestMethod]
        public void VoorlettersMetRVergelijkInhoud_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag1Comprehension();

            // Assert
            var expectedResult = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }

        #endregion

        #endregion

        #region Vraag 2

        #region Lamda

        [TestMethod]
        public void ControleerEersteLengte()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2();

            // Assert
            Assert.AreEqual(3, result.FirstOrDefault());
        }

        [TestMethod]
        public void ControleerEerste3NamenBeginnedMetJ()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2();

            // Assert
            var expectedResult = new List<int> { 3, 5, 5 };
            CollectionAssert.AreEqual(expectedResult, result.Take(3).ToList());
        }

        [TestMethod]
        public void TelNaamKaraktersVanEersteBeginnendMetJ()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2();

            // Assert
            Assert.AreEqual(3, result.FirstOrDefault());
        }

        [TestMethod]
        public void ControleerHoogsteLengte()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2();

            // Assert
            Assert.AreEqual(8, result.LastOrDefault());
        }

        [TestMethod]
        public void ControleerResultaatKeysMetVerwacht()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 3, 5, 5, 6, 8 }, result.ToList());
        }

        #endregion

        #region Comprehension

        [TestMethod]
        public void ControleerEersteLengte_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2Comprehension();

            // Assert
            Assert.AreEqual(3, result.FirstOrDefault());
        }

        [TestMethod]
        public void ControleerEerste3NamenBeginnedMetJ_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2Comprehension();

            // Assert
            var expectedResult = new List<int> { 3, 5, 5 };
            CollectionAssert.AreEqual(expectedResult, result.Take(3).ToList());
        }

        [TestMethod]
        public void TelNaamKaraktersVanEersteBeginnendMetJ_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2Comprehension();

            // Assert
            Assert.AreEqual(3, result.FirstOrDefault());
        }

        [TestMethod]
        public void ControleerHoogsteLengte_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2Comprehension();

            // Assert
            Assert.AreEqual(8, result.LastOrDefault());
        }

        [TestMethod]
        public void ControleerResultaatKeysMetVerwacht_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag2Comprehension();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 3, 5, 5, 6, 8 }, result.ToList());
        }

        #endregion

        #endregion

        #region Vraag 3

        #region Lambda

        [TestMethod]
        public void ControleerAantalGroepen()
        {
            // Arange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag3();

            // Assert
            Assert.AreEqual(7, result.ToList().Count);
        }

        [TestMethod]
        public void ControleerGroepen()
        {
            // Arange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag3();
            var expectedResult = new List<int> { 4, 4, 6, 5, 3, 1, 1 };

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result.ToList());
        }

        #endregion

        #region Comprehension

        [TestMethod]
        public void ControleerAantalGroepen_Comprehension()
        {
            // Arange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag3Comprehension();

            // Assert
            Assert.AreEqual(7, result.ToList().Count);
        }

        [TestMethod]
        public void ControleerGroepen_Comprehension()
        {
            // Arange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag3Comprehension();
            var expectedResult = new List<int> { 4, 4, 6, 5, 3, 1, 1 };

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result.ToList());
        }

        #endregion

        #endregion

        #region Vraag 4

        #region Lambda

        [TestMethod]
        public void geeftKleinsteNamen()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag4();

            // Assert
            var expectedResult = new List<string> { "Pim", "Rob" };
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }

        [TestMethod]
        public void geeftKleinsteNamenMetAdIsLegeLijst()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();
            target.PersonList = new List<string>
            {
                "Yael", "Rouke", "Wesley", "Simon", "Martin", "Jelle",
                "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
                "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
                "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery", "Ad"
            };

            // Act
            var result = target.Vraag4();

            // Assert
            var expectedResult = new List<string>();
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }

        #endregion

        #region Comprehension

        [TestMethod]
        public void geeftKleinsteNamen_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();

            // Act
            var result = target.Vraag4Comprehension();

            // Assert
            var expectedResult = new List<string> { "Pim", "Rob" };
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }


        [TestMethod]
        public void geeftKleinsteNamenMetAdIsLegeLijst_Comprehension()
        {
            // Arrange
            var target = new LinqOefening.LinqOefening();
            target.PersonList = new List<string>
            {
                "Yael", "Rouke", "Wesley", "Simon", "Martin", "Jelle",
                "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
                "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
                "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery", "Ad"
            };

            // Act
            var result = target.Vraag4Comprehension();

            // Assert
            var expectedResult = new List<string>();
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }

        #endregion

        #endregion
    }
}
