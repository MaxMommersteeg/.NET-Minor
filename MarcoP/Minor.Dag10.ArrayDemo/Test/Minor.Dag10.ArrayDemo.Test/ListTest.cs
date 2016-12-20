using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.ArrayDemo.Test
{
    [TestClass]
    public class ListTest
    {
        //[TestMethod]
        //public void MakeListTest()
        //{
        //    IntList a = new IntList() { 2, 3, 5, 6, 7, 87, 8889 };

        //    int result = a[0];
        //    a[0] = 5;
        //}

        [TestMethod]
        public void EmptyListHasCount0()
        {
            // Arrange
            var target = new List<int>();

            // Act
            int result = target.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ListWithAddHasCount1()
        {
            var target = new List<int>();

            target.Add(5);

            Assert.AreEqual(1, target.Count);
        }


        [TestMethod]
        public void ListWithAddActuallyAdds()
        {
            var target = new List<int>();
            target.Add(5);

            int result = target[0];

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ListWithMulitpleAddActuallyAdds()
        {
            var target = new List<int>();

            target.Add(5);
            target.Add(7);

            Assert.AreEqual(5, target[0]);
            Assert.AreEqual(7, target[1]);
        }

        [TestMethod]
        public void ListIndexOutOfRangeException()
        {
            var target = new List<int>();
            target.Add(5);
            target.Add(7);

            Action action = () => {
                int result = target[2];
            };

            Assert.ThrowsException<IndexOutOfRangeException>(action);
        }

        [TestMethod]
        public void ListWithMoreThan4Adds()
        {
            var target = new List<int>();

            target.Add(2);
            target.Add(3);
            target.Add(5);
            target.Add(7);
            target.Add(11);
            target.Add(13);

            Assert.AreEqual(6, target.Count);
        }


        [TestMethod]
        public void SetterTest()
        {
            var target = new List<int>();
            target.Add(5);
            target.Add(7);

            target[0] = 2;

            Assert.AreEqual(2, target[0]);
        }

        [TestMethod]
        public void IEnumerableTest()
        {
            int count = 0;
            int sum = 0;
            List<int> lijst = new List<int>();
            lijst.Add(2);
            lijst.Add(3);
            lijst.Add(5);

            foreach (var item in lijst)
            {
                count++;
                sum += item;
            }

            Assert.AreEqual(3, count, "An incorrect number of items has been enumerated");
            Assert.AreEqual(10, sum, "sum");
        }
    }
}
