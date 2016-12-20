using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag08.ParameterDemo.Test
{
    [TestClass]
    public class ParameterTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var target = new DemoDing();
            int k;

            target.MakeSix(out k);

            target.AddOne(ref k);

            Assert.AreEqual(7, k);
        }

        [TestMethod]
        public void OverloadingTest()
        {
            var target = new DemoDing();

            target.M();
            target.M(4);
            target.M(2, 3);
            target.M(1, 2, 3);
            target.M(a: 1, b: 2, c: 3);
            target.M(a: 1, c: 3);
            target.M(1, c: 3);
            target.M(c: 3, b: 2, a: 1);
            int a = 4;
            target.M(1, 3);

            target.M(new int[] { 2, 3, 5, 7, 11 });
        }
    }
}
