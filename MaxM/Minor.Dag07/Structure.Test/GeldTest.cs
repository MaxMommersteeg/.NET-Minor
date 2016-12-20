using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Structure.Test
{
    [TestClass]
    public class GeldTest
    {
        [TestMethod]
        public void AanmakenGeldTest()
        {
            // Arrange
            var target = new Geld(10.0M, Muntsoort.Euro);

            // Assert
            Assert.AreNotEqual(null, target);
        }

        [TestMethod]
        public void GeldToStringTest()
        {
            // Arrange
            var target = new Geld(20.0M, Muntsoort.Euro);

            // Act
            var result = target.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("Euro 20"));
            Assert.AreEqual(true, result.Contains("00"));
        }

        [TestMethod]
        public void GeldToStringBedragTest()
        {
            // Arrange
            var target = new Geld(20.0M, Muntsoort.Euro);

            // Act
            var result = target.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("20"));
            Assert.AreEqual("Euro", result.Substring(0, 4));
        }

        [TestMethod]
        public void GeldConversieTest()
        {
            // Arrange
            var target = new Geld(20.0M, Muntsoort.Euro);

            // Act
            var result = target.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("20"));
            Assert.AreEqual("Euro", result.Substring(0, 4));
        }

        [TestMethod]
        public void GeldConversieOnbekendeValutaTest()
        {
            // Arrange
            var target = new GeldConverter();

            // Act -> Assert
            Assert.ThrowsException<OnbekendeValuteExceptie>(() => target.ValutaNaarEuro(10.0M, Muntsoort.Onbekend));
        }

        [TestMethod]
        public void GeldGuldenNaarEuroTest()
        {
            // Arrange
            var target = new GeldConverter();
            var euro = 10.0M;
            var koers = 2.20371M;

            // Act
            var result = target.GuldenNaarEuro(euro);
            var expected = euro / koers;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GeldFlorijnNaarEuroTest()
        {
            // Arrange
            var target = new GeldConverter();
            var euro = 10.0M;
            var koers = 2.20371M;

            // Act
            var result = target.FlorijnNaarEuro(euro);
            var expected = euro / koers;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GeldDukaatNaarEuroTest()
        {
            // Arrange
            var target = new GeldConverter();
            var euro = 10.0M;
            var koers = 11.238921M;

            // Act
            var result = target.DukaatNaarEuro(euro);
            var expected = euro / koers;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GeldEuroValutaNaarEuroTest()
        {
            // Arrange
            var target = new GeldConverter();
            var euro = 10.0M;
            var koers = 1M;

            // Act
            var result = target.ValutaNaarEuro(euro, Muntsoort.Euro);
            var expected = euro / koers;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GeldDukaatValutaNaarEuroTest()
        {
            // Arrange
            var target = new GeldConverter();
            var dukaat = 10.0M;
            var koers = 11.238921M;

            // Act
            var result = target.ValutaNaarEuro(dukaat, Muntsoort.Dukaat);
            var expected = dukaat / koers;
            expected = expected * koers;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GeldEqualsGeldTest()
        {
            // Arrange
            var bedrag = 10.0M;
            var muntsoort = Muntsoort.Euro;
            var geld1 = new Geld(bedrag, muntsoort);
            var geld2 = new Geld(bedrag, muntsoort);

            // Act
            var result = geld1.Equals(geld2);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GeldEqualsAlternatiefBedragGeldTest()
        {
            // Arrange
            var bedrag = 10.0M;
            var alternatiefBedrag = 10.1M;
            var muntsoort = Muntsoort.Euro;
            var geld1 = new Geld(bedrag, muntsoort);
            var geld2 = new Geld(alternatiefBedrag, muntsoort);

            // Act
            var result = geld1.Equals(geld2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GeldEqualsAlternatiefMuntsoortGeldTest()
        {
            // Arrange
            var bedrag = 10.0M;
            var muntsoort = Muntsoort.Euro;
            var alternatiefMuntsoort = Muntsoort.Florijn;
            var geld1 = new Geld(bedrag, muntsoort);
            var geld2 = new Geld(bedrag, alternatiefMuntsoort);

            // Act
            var result = geld1.Equals(geld2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GeldAdd10GeldTest()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 + geld2;

            // Assert
            Assert.AreEqual(true, result.ToString().Contains("Euro"));
            Assert.AreEqual(true, result.ToString().Contains("20"));
        }

        [TestMethod]
        public void GeldAdd20GeldTest()
        {
            // Arange
            var bedrag = 20.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 + geld2;

            // Assert
            Assert.AreEqual(true, result.ToString().Contains("Euro"));
            Assert.AreEqual(true, result.ToString().Contains("40"));
        }

        [TestMethod]
        public void GeldAddNegative20GeldTest()
        {
            // Arange
            var bedrag = -20.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 + geld2;

            var bedragInEuro = result.ToString().Split(' ')[1];

            // Assert
            Assert.AreEqual(true, result.ToString().Contains("Euro"));
            // Must contain a negative sign
            Assert.AreEqual(true, bedragInEuro.Contains("-"));
        }

        [TestMethod]
        public void GeldSubtract20GeldTest()
        {
            // Arange
            var bedrag = 20.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 - geld2;

            // Assert
            Assert.AreEqual(true, result.ToString().Contains("Euro"));
            Assert.AreEqual(true, result.ToString().Contains("0"));
        }

        [TestMethod]
        public void GeldSubtract5From10GeldTest()
        {
            // Arange
            var beginBedrag = 10.0M;
            var subtractBedrag = 5.0M;
            var geld1 = new Geld(beginBedrag, Muntsoort.Euro);
            var geld2 = new Geld(subtractBedrag, Muntsoort.Euro);

            // Act
            var result = geld1 - geld2;

            // Assert
            Assert.AreEqual(true, result.ToString().Contains("Euro"));
            Assert.AreEqual(true, result.ToString().Contains("5"));
        }

        [TestMethod]
        public void GeldVergelijkMetGeldGelijkTest()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 == geld2;

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GeldVergelijkMetGeldOngelijkTest()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Gulden);

            // Act
            var result = geld1 == geld2;

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GeldVergelijkMetGeldOngelijk2Test()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Gulden);

            // Act
            var result = geld1 != geld2;

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GeldCompareHash1codes()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1.GetHashCode();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GeldCompareHashcodes()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);
            var geld2 = new Geld(bedrag, Muntsoort.Gulden);

            // Act
            var geld1Hashcode = geld1.GetHashCode();
            var geld2Hashcode = geld2.GetHashCode();

            var result = geld1Hashcode == geld2Hashcode;

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GeldIsNullCompareTest()
        {
            // Arange
            var bedrag = 10.0M;
            var geld1 = new Geld(bedrag, Muntsoort.Euro);

            // Act
            var result = geld1 == null;

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
