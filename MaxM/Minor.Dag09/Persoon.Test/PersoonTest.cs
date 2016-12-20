using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persoon.Test
{
    [TestClass]
    public class PersoonTest
    {

        [TestMethod]
        public void PersoonVerjaarAanroep()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(23);

            // Assert
            Assert.IsTrue(leeftijdChangedMock.LeeftijdChangedCalled);
        }

        [TestMethod]
        public void PersoonVerjaarResultaatCorrect()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(23);

            // Assert
            Assert.AreEqual(23, leeftijdChangedMock.LeeftijdChangedEventArgs.NieuweLeeftijd);
        }

        [TestMethod]
        public void PersoonLeeftijdParameterCorrect()
        {

        }

        [TestMethod]
        public void PersoonLeeftijdParameterIncorrect()
        {

        }

        [TestMethod]
        public void PersoonVerjaarEventVerwijderdNietAangeroepen()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(12);

            target.LeeftijdChanged -= leeftijdChangedMock.LeeftijdChangedHandled;
            target.Verjaar(48);

            // Assert
            Assert.AreEqual(12, leeftijdChangedMock.LeeftijdChangedEventArgs.NieuweLeeftijd);
        }

        [TestMethod]
        public void PersoonTweemaalVerjaardCorrecteOutput()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(12);
            target.Verjaar(15);

            // Assert
            Assert.AreEqual(15, leeftijdChangedMock.LeeftijdChangedEventArgs.NieuweLeeftijd);
        }

        [TestMethod]
        public void PersoonOudeLeeftijdEnNieuweLeeftijdCorrect()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(12);

            // Assert
            Assert.AreEqual(22, leeftijdChangedMock.LeeftijdChangedEventArgs.OudeLeeftijd);
            Assert.AreEqual(12, leeftijdChangedMock.LeeftijdChangedEventArgs.NieuweLeeftijd);
        }

        [TestMethod]
        public void PersoonNaamCorrect()
        {
            // Arrange
            var target = new Persoon(22, "Max");
            var leeftijdChangedMock = new LeeftijdChangedMock();
            target.LeeftijdChanged += leeftijdChangedMock.LeeftijdChangedHandled;

            // Act
            target.Verjaar(12);

            // Assert
            Assert.AreEqual("Max", target.Naam);
            Assert.AreEqual("Max", leeftijdChangedMock.LeeftijdChangedEventArgs.Naam);
        }
    }
}
