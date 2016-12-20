using FrontEnd.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrontEnd.MVC.Test.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void GetIso8601WeekOfYearValid1Test()
        {
            // Arrange
            var date = new DateTime(2016, 10, 11);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(41, result);
        }

        [TestMethod]
        public void GetIso8601WeekOfYearValid2Test()
        {
            // Arrange
            var date = new DateTime(2016, 12, 31);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(52, result);
        }

        [TestMethod]
        public void GetIso8601WeekOfYearValid4Test()
        {
            // Arrange
            var date = new DateTime(2016, 12, 30);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(52, result);
        }

        [TestMethod]
        public void GetIso8601WeekOfYearValid5Test()
        {
            // Arrange
            var date = new DateTime(2016, 1, 1);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(53, result);
        }

        [TestMethod]
        public void GetIso8601WeekOfYearValid6Test()
        {
            // Arrange
            var date = new DateTime(2015, 1, 1);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetIso8601WeekOfYearValid7Test()
        {
            // Arrange
            var date = new DateTime(2015, 12, 31);

            // Act
            var result = date.GetIso8601WeekOfYear();

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(53, result);
        }
    }
}
