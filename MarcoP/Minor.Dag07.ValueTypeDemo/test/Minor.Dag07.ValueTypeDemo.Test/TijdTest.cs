using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag07.ValueTypeDemo.Test
{
    [TestClass]
    public class TijdTest
    {
        [TestMethod]
        public void TijdConstructor()
        {
            Tijd tijdstip = new Tijd(11, 45);

            Assert.AreEqual(11, tijdstip.Uren);
            Assert.AreEqual(45, tijdstip.Minuten);
        }

        [TestMethod]
        public void TijdPlusVijf()
        {
            Tijd tijdstip = new Tijd(11, 45);

            Tijd nieuwTijdstip = tijdstip.PlusMinuten(5);

            Assert.AreEqual(11, nieuwTijdstip.Uren);
            Assert.AreEqual(50, nieuwTijdstip.Minuten);
        }


        [TestMethod]
        public void TijdPlusVijfentwintig()
        {
            Tijd tijdstip = new Tijd(11, 45);

            Tijd nieuwTijdstip = tijdstip.PlusMinuten(25);

            Assert.AreEqual(12, nieuwTijdstip.Uren);
            Assert.AreEqual(10, nieuwTijdstip.Minuten);
        }


        [TestMethod]
        public void TijdenVergelijken()
        {
            Tijd t1 = new Tijd(11, 45);
            Tijd t2 = new Tijd(11, 45);

            bool result = t1.Equals(t2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WaardesVergelijken()
        {
            int a = 3;
            JP jp = new JP(3);

            bool result = a.Equals(jp);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TijdenOptellen()
        {
            Tijd t1 = new Tijd(3, 15);
            Tijd t2 = new Tijd(2, 30);

            Tijd result = t1 + t2;

            Assert.AreEqual(new Tijd(5, 45), result);

        }

        [TestMethod]
        public void TijdenOptellen2()
        {
            Tijd t1 = new Tijd(3, 15);
            Tijd t2 = new Tijd(2, 45);

            Tijd result = t1 + t2;

            Assert.AreEqual(new Tijd(6, 00), result);
        }

        [TestMethod]
        public void TijdPlus5()
        {
            Tijd t1 = new Tijd(3, 15);

            Tijd result = t1 + 5;

            Assert.AreEqual(new Tijd(3, 20), result);
        }
        [TestMethod]
        public void IntToTijd()
        {
            int a = 5;

            Tijd result = a;

            Assert.AreEqual(new Tijd(0,5), result);
        }

        [TestMethod]
        public void Tijd5Plus()
        {
            Tijd t1 = new Tijd(3, 15);

            Tijd result = (Tijd)5 + t1;

            Assert.AreEqual(new Tijd(3, 20), result);
        }

        [TestMethod]
        public void Tijd70Plus()
        {
            Tijd t1 = new Tijd(3, 15);

            Tijd result = (Tijd)70 + t1;

            Assert.AreEqual(new Tijd(4, 25), result);
        }

        [TestMethod]
        public void TijdenGelijk()
        {
            Tijd t1 = new Tijd(11, 45);
            Tijd t2 = new Tijd(11, 45);

            bool result = t1 == t2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TijdenOngelijk()
        {
            Tijd t1 = new Tijd(11, 45);
            Tijd t2 = new Tijd(11, 46);

            bool result = t1 != t2;

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TijdenGetHashcodeTest()
        {
            Tijd t1 = new Tijd(11, 45);
            Tijd t2 = new Tijd(11, 45);

            int h1 = t1.GetHashCode();
            int h2 = t2.GetHashCode();

            Assert.IsTrue(h1 == h2);
        }


        [TestMethod]
        public void TijdIncrement()
        {
            Tijd t1 = new Tijd(11, 45);

            Tijd t2 = t1++;

            Assert.AreEqual(new Tijd(11, 46), t1);
            Assert.AreEqual(new Tijd(11, 45), t2);
        }


        [TestMethod]
        public void TijdIncrementBefore()
        {
            Tijd t1 = new Tijd(11, 45);

            Tijd t2 = ++t1;

            Assert.AreEqual(new Tijd(11, 46), t1);
            Assert.AreEqual(new Tijd(11, 46), t2);
        }
    }
}
