using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GeldTest
{
    [TestClass]
    public class ValutaTest
    {

        [TestMethod]
        public void ValutaToStringStandaardTest()
        {
            //Arrange

            //Act
            Geld geld = new Geld(30.00M);

            //Assert
            Assert.AreEqual(Valuta.Euro.ToString() + " " + 30.00M.ToString(), geld.ToString());
        }

        [TestMethod]
        public void ValutaToStringTest()
        {
            //Arrange

            //Act
            Geld geld = new Geld(Valuta.Euro, 30.00M);

            //Assert
            Assert.AreEqual(Valuta.Euro.ToString() + " " + 30.00M.ToString(), geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToGuldenFromEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 30.00M);
            decimal NieuwBedrag = 30.00M * 2.20371M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Gulden.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Gulden);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToEuroFromGuldenTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Gulden, 30.00M);
            decimal NieuwBedrag = 30.00M / 2.20371M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Euro.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Euro);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToDukaatFromEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 30.00M);
            decimal NieuwBedrag = 30.00M * 2.20371M/5.1M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Dukaat);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToFlorijnFromFlorijnTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Florijn, 30.00M);
            decimal NieuwBedrag = 30.00M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Florijn.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Florijn);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToFlorijnFromEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 30.00M);
            decimal NieuwBedrag = 30.00M * 2.20371M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Florijn.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Florijn);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToEuroFromDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 30.00M);
            decimal NieuwBedrag = 30.00M / 2.20371M * 5.1M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Euro.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Euro);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void ValutaConvertToDukaatFromDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 30.00M);
            decimal NieuwBedrag = 30.00M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            geld.ConvertTo(Valuta.Dukaat);

            //Assert
            Assert.AreEqual(target, geld.ToString());
        }

        [TestMethod]
        public void GeldPlusGeldTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 30.00M);
            Geld money = new Geld(Valuta.Dukaat, 30.00M);

            decimal NieuwBedrag = 60.00M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld + money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void DukaatPlusEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 30.00M);
            Geld money = new Geld(Valuta.Euro, 30.00M);

            decimal NieuwBedrag = (30.00M * 2.20371M / 5.1M) + 30M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld + money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void EuroPlusDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 30.00M);
            Geld money = new Geld(Valuta.Dukaat, 30.00M);

            decimal NieuwBedrag = (30.00M / 2.20371M * 5.1M) + 30M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Euro.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld + money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void GuldenPlusFlorijnTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Florijn, 30.00M);
            Geld money = new Geld(Valuta.Gulden, 30.00M);

            decimal NieuwBedrag = 30.00M  + 30M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Florijn.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld + money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void FlroijnPlusGuldenTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Gulden, 30.00M);
            Geld money = new Geld(Valuta.Florijn, 30.00M);

            decimal NieuwBedrag = 30.00M + 30M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Gulden.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld + money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void DukaatMaalDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 30.00M);
            Geld money = new Geld(Valuta.Dukaat, 30.00M);

            decimal NieuwBedrag = 30.00M * 30.00M;
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld * money;

            //Assert
            Assert.AreEqual(target, result.ToString());
        }

        [TestMethod]
        public void EuroMaalDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 20.00M);
            Geld money = new Geld(Valuta.Dukaat, 30.00M);

            decimal NieuwBedrag = 20.00M;
            NieuwBedrag = Math.Round(NieuwBedrag / 2.20371M,10);
            NieuwBedrag = Math.Round(NieuwBedrag * 5.1M, 5);
            NieuwBedrag = NieuwBedrag * 30M;
            decimal NieuwBedragRounded = Math.Round(Math.Round(NieuwBedrag, 1),2);
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedragRounded);
            string target = Valuta.Euro.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld * money;

            //Assert
            Assert.AreEqual(NieuwBedragString, result.ToString().Split(' ')[1]);
        }

        [TestMethod]
        public void EuroMaalDecimalTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Euro, 20.00M);
           
            decimal NieuwBedrag = 20.00M * 10M;
           
            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Euro.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld * 10M;

            //Assert
            Assert.AreEqual(NieuwBedragString, result.ToString().Split(' ')[1]);
        }

        [TestMethod]
        public void DukaatMaalDecimalTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 20.00M);

            decimal NieuwBedrag = 20.00M * 10M;

            string NieuwBedragString = string.Format("{0:N2}", NieuwBedrag);
            string target = Valuta.Dukaat.ToString() + " " + NieuwBedragString;

            //Act
            Geld result = geld * 10M;

            //Assert
            Assert.AreEqual(NieuwBedragString, result.ToString().Split(' ')[1]);
        }

        [TestMethod]
        public void DukaatISISDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 20.00M);
            Geld money = new Geld(Valuta.Dukaat, 20.00M);
            
            //Act
            bool result = geld == money;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DukaatNietIsDukaatTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 20.00M);
            Geld money = new Geld(Valuta.Dukaat, 30.00M);

            //Act
            bool result = geld != money;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DukaatISISEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 20.00M);
            Geld money = new Geld(Valuta.Euro, 30.00M);

            //Act
            bool result = geld == money;

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DukaatNietISEuroTest()
        {
            //Arrange
            Geld geld = new Geld(Valuta.Dukaat, 20.00M);
            Geld money = new Geld(Valuta.Euro, 30.00M);

            //Act
            bool result = geld != money;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DecimalToValutaCastTest()
        {
            //arrange
            Geld money = new Geld(Valuta.Euro, 30.00M);

            //act
            Geld geld = (Geld)30.00M;

            //assert
            Assert.AreEqual(money.ToString(),geld.ToString());
        }

        [TestMethod]
        public void ValutaToGeldCastTest()
        {
            //arrange
            Geld money = new Geld(Valuta.Euro, 30.00M);

            //act
            decimal geld = (decimal)money;

            //assert
            Assert.AreEqual(30.00M, geld);
        }

        [TestMethod]
        public void ValutaToGeldCastPlusConvertTest()
        {
            //arrange
            Geld money = new Geld(Valuta.Gulden, 30.00M);
            decimal target = Math.Round(30.00M / 2.20371M,2);
            //act
            decimal geld = (decimal)money;

            //assert
            Assert.AreEqual(target, geld);
        }

    }
}
