using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQLijst;
using System.Diagnostics;

namespace LINQLijstQueriesTesten
{
    [TestClass]
    public class LinQQueriesTesten
    {
        #region Opdracht 1


        [TestMethod]
        public void LijstEersteWaardeOphalen()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);



            //Act
            string result = target.First();

            //Assert
            Assert.AreEqual("Yael", result);
        }

        [TestMethod]
        public void LijstEersteLettersOphalen()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<char> { 'Y', 'R', 'W' };



            //Act
            List<char> result = target.FirstLetters();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstEersteLettersOphalenBevattendeRKlein()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<char> { 'R' };



            //Act
            List<char> result = target.FirstLettersContaining("R");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstEersteLettersOphalenBevattendeRKlein2()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Jeroen","Wesley"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<char> { 'J' };



            //Act
            List<char> result = target.FirstLettersContaining("R");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstEersteLettersOphalenBevattendeRVolledigeLijst()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };



            //Act
            List<char> result = target.FirstLettersContaining("R");


            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstEersteLettersOphalenBevattendeRVolledigeLijstAlternate()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<char> { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };



            //Act
            List<char> result = target.FirstLettersContainingLambdaMethod("R");


            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        #endregion

        #region BeginLetterJEnNaamLengte



        [TestMethod]
        public void LijstGroupingCountStartsWithJ()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 8, 6, 5, 5, 3 };



            //Act
            List<int> result = target.GroupCountStartingWithDesc('J');

            //Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void LijstGroupingCountStartsWithJDescending()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 8, 6, 5, 5, 3 };



            //Act
            List<int> result = target.GroupCountStartingWithDesc('J');

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstGroupingCountStartsWithJDescendingLambda()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert - Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 8, 6, 5, 5, 3 };



            //Act
            List<int> result = target.GroupCountStartingWithDescLambda('J');

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        #endregion

        #region GroeperenOpNaamLengteEnDanGroepGrootte


        [TestMethod]
        public void LijstGroupingNameLength()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 4, 4, 6, 5, 3, 1, 1 };



            //Act
            List<int> result = target.GroupNameLength();

            //Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void LijstGroupingNameLengthMinCount0()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 4, 4, 6, 5, 3, 1, 1 };



            //Act
            List<int> result = target.GroupNameLength();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstGroupingNameLengthMinCount0Lambda()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<int> { 4, 4, 6, 5, 3, 1, 1 };



            //Act
            List<int> result = target.GroupNameLengthLambda();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        #endregion

        #region LijstMetKortsteNamenZonderA


        [TestMethod]
        public void LijstKortsteNamen()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Max", "Rob", "Pim", "Jan" };



            //Act
            List<string> result = target.ListShortestNames();

            //Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraint()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Pim", "Rob" };



            //Act
            List<string> result = target.ListShortestNames("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintHoofdletter()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Pim", "Rob" };



            //Act
            List<string> result = target.ListShortestNames("A");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintMetAdMetJe()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery", "Ad", "Je"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Je" };



            //Act
            List<string> result = target.ListShortestNames("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintMetAd()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery", "Ad"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> {  };



            //Act
            List<string> result = target.ListShortestNames("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintLambda()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Pim", "Rob" };



            //Act
            List<string> result = target.ListShortestNamesLambda("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintLambdaHoofdLetter()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Pim", "Rob" };



            //Act
            List<string> result = target.ListShortestNamesLambda("A");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintMetAdLambda()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery", "Ad"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> {  };



            //Act
            List<string> result = target.ListShortestNamesLambda("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LijstKortsteNamenMetRestraintMetAdLambdaMetJe()
        {
            //Arrange
            var lijst = new List<string> {
                "Yael", "Rouke","Wesley","Simon","Martin","Jelle",
                "Martijn","Robert-Jan","Rob","Pim","Vincent","Wouter",
                "Misha","Steven","Jeroen","Max","Menno","Rory",
                "Jan","Jan-Paul","Michiel","Gert","Lars","Joery", "Ad", "Je"
            };

            var target = new LinqQueries(lijst);
            var expected = new List<string> { "Je" };



            //Act
            List<string> result = target.ListShortestNamesLambda("a");

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }
        #endregion

    }
}

