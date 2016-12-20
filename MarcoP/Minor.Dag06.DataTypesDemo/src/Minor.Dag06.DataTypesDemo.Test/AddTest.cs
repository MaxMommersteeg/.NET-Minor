using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag06.DataTypesDemo.Test
{
    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void OneAndOneTest()
        {
            //Arrange
            int a = 1;
            int b = 1;

            // Act
            int result = a + b;

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void doubleOrDecimalTest()
        {
            // Arrange
            decimal a = 0.3M - 0.2M;
            decimal b = 0.2M - 0.1M;

            // Act
            bool result = a == b;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void abc_test()
        {
            // Arrange
            int a = 3;
            int b = 5;
            int c = 7;

            // Act
            c = ++a==a++?b=c+a++:b=++a-c;

            // Assert
            Assert.AreEqual(6 , a);
            Assert.AreEqual(12 , b);
            Assert.AreEqual(12 , c);
        }
        [TestMethod]
        public void NO_Spaceship()
        {
            int a = 3;
            int b = 4;

            //int result = a <=> b;

        }
    }
}
