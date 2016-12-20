using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag06.DataTypesDemo.Test
{
    [TestClass]
    public class TwilightTest
    {
        [TestMethod]
        public void FindStrangeDoubleTest()
        {
            var target = new Twilight();

            double x = target.FindStrangeDouble();

            Assert.IsTrue(x == x + 1);
        }

        [TestMethod]
        public void FindSmallestStrangeDoubleTest()
        {
            var target = new Twilight();

            double x = target.FindSmallestStrangeDouble();

            Assert.IsTrue(x > 0);
            Assert.IsTrue(x < 1e30);    // hhmmmm... kan dit beter?
            Assert.IsTrue(x == x + 1);
            #region antwoord
            // 9,007,199,254,740,992
            Assert.AreEqual(9007199254740992, x);
            #endregion
        }
    }
}
