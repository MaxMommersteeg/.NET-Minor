using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRegEx
{
    [TestClass]
    public class RegExTest
    {
        [TestMethod]
        public void CorrectGetalFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("2.00");

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InCorrectGetalDecimaalTeWeinigFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("2.0");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InCorrectGetalDecimaalTeVeelFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("2.000");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InCorrectGetalLetteripvPuntFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("2B00");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InCorrectGetalBegintNietMetMinOfGetalFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("+2.00");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectGetalBegintMetMinFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("-2.00");

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InCorrectGetalBegintMetLetterFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("A2.00");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InCorrectGetalFouteDuizendSeperatorFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("20,0000.00");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectGetalGoedeDuizendSeperatorFormatTest()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("200,000.00");

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InCorrectGetalFouteDuizendSeperatorFormatTest2()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check("2000,00.00");

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InCorrectGetalBeginMetDuizendSeperatorFormatTest2()
        {
            //arrange
            RegEx checker = new RegEx();

            //act
            bool result = checker.Check(",200.00");

            //assert
            Assert.IsFalse(result);
        }
    }
}
