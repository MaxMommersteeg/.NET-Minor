using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag08.StringEnRegexDemo.Test
{
    [TestClass]
    public class PostcodeCheckerTest
    {
        [TestMethod]
        public void CorrectePostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1001AA");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NIET_MinderDan4cijfersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("123AA");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NIET_MeerDan4cijfersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("12345AA");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NIET_MinderDan2LettersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1234A");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NIET_MeerDan2LettersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1234ABC");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void optioneleSpatiePostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1234 AB");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ofMetKleineLettersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1234ab");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NIET_MixVanGroteEnKleineLettersPostcode()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("1234Ab");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BUG_PostcodeMetTweeKleineLettersWordtFoutiefGeaccepteerd()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("ab");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BUG_PostcodeBeginnendMet0WordtFoutiefGeaccepteerd()
        {
            var target = new PostcodeChecker();

            bool result = target.Check("0123 EF");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CijfersVanPostcode()
        {
            var target = new PostcodeChecker();

            string cijfers = target.Cijfers("1235 EF");

            Assert.AreEqual("1235", cijfers);
        }

        [TestMethod]
        public void LettersVanPostcode()
        {
            var target = new PostcodeChecker();

            string letters = target.Letters("1235 EF");

            Assert.AreEqual("EF", letters);
        }
    }
}
