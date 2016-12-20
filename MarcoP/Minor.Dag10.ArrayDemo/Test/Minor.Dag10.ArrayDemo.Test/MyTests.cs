using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.ArrayDemo.Test
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            int[,]  rectangular = { { 1, 2, 3 }, { 3, 4, 5 } };
            int[][] ragged = { new int[]{ 1, 2, 3 }, new int[] { 2 }, new int[] { 3, 4 } };
        }

        [TestMethod]
        public void ArrayResizeTest()
        {
            int[] target = { 2, 3, 5, 7 };

            Resize(ref target, newSize: 7);

            Assert.AreEqual(7, target.Length);
        }

        [TestMethod]
        public void ArrayResizeKeepsValuesTest()
        {
            int[] target = { 2, 3, 5, 7 };

            Resize(ref target, newSize: 7);

            Assert.AreEqual(2, target[0]);
            Assert.AreEqual(3, target[1]);
            Assert.AreEqual(5, target[2]);
            Assert.AreEqual(7, target[3]);
            Assert.AreEqual(0, target[4]);
            Assert.AreEqual(0, target[5]);
            Assert.AreEqual(0, target[6]);
        }


        [TestMethod]
        public void ArrayResizeToSmallerTest()
        {
            int[] target = { 2, 3, 5, 7 };

            Resize(ref target, newSize: 2);

            Assert.AreEqual(2, target.Length);
            Assert.AreEqual(2, target[0]);
            Assert.AreEqual(3, target[1]);
        }

        private void Resize(ref int[] oldArray, int newSize)
        {
            int[] newArray = new int[newSize];
            for (int i = 0; i < Math.Min(oldArray.Length, newSize); i++)
            {
                newArray[i] = oldArray[i];
            }
            oldArray = newArray;
        }
    }
}
