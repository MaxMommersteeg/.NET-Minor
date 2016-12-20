using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Minor.Dag09.EventOefening.Test
{
    [TestClass]
    public class PersoonTest
    {
        [TestMethod]
        public void PersoonMoetNaamEnLeeftijdHebben()
        {
            // Act
            Persoon persoon = new Persoon(naam: "Marco", leeftijd: 45);

            // Assert
            Assert.AreEqual("Marco", persoon.Naam);
            Assert.AreEqual(45, persoon.Leeftijd);
        }

        [TestMethod]
        public void PersoonMoetVerjaren()
        {
            var target = new Persoon(naam: "Marco", leeftijd: 45);

            target.Verjaar();

            Assert.AreEqual(46, target.Leeftijd);
        }

        [TestMethod]
        public void LeeftijdChangedIsRaisedBijVerjaren()
        {
            var target = new Persoon(naam: "Marco", leeftijd: 45);
            EventListenerMock mock = new EventListenerMock();
            target.LeeftijdChanged += new LeeftijdChangedEventHandler(mock.Listen);

            target.Verjaar();

            Assert.AreEqual(1, mock.ReceivedTimes);
        }


        [TestMethod]
        public void LeeftijdChangedIsRaisedBijLeeftijdSet()
        {
            var target = new Persoon(naam: "Marco", leeftijd: 45);
            EventListenerMock mock = new EventListenerMock();
            target.LeeftijdChanged += new LeeftijdChangedEventHandler(mock.Listen);

            target.Leeftijd = 25;

            Assert.AreEqual(1, mock.ReceivedTimes);
        }


        [TestMethod]
        public void LeeftijdChangedIsRaisedOnlyOnce()
        {
            var target = new Persoon(naam: "Marco", leeftijd: 45);
            EventListenerMock mock = new EventListenerMock();
            target.LeeftijdChanged += new LeeftijdChangedEventHandler(mock.Listen);

            target.Verjaar();

            Assert.AreEqual(1, mock.ReceivedTimes);
        }

        [TestMethod]
        public void LeeftijdChangedMakesCorrectValuesAvailable()
        {
            var target = new Persoon(naam: "Marco", leeftijd: 45);
            EventListenerMock mock = new EventListenerMock();
            target.LeeftijdChanged += new LeeftijdChangedEventHandler(mock.Listen);

            target.Verjaar();

            Assert.AreEqual(45, mock.EventArgs.OudeLeeftijd);
            Assert.AreEqual(46, mock.EventArgs.NieuweLeeftijd);
            Assert.AreEqual(target, mock.Sender);
            //Assert.AreEqual("Marco", mock.Sender.Naam);
        }

        [TestMethod]
        public void WerknemerHeeftSalaris()
        {
            Werknemer target = new Werknemer(naam: "Jan", leeftijd: 40, salaris: 1000.00M);

            Assert.AreEqual(1000.00M, target.Salaris);
        }


        [TestMethod]
        public void WerknemerSalarisVerhoogtMetEenJaar()
        {
            Werknemer target = new Werknemer(naam: "Jan", leeftijd: 40, salaris: 1000.00M);

            target.Verjaar();

            Assert.AreEqual(1010.00M, target.Salaris);
        }

        [TestMethod]
        public void WerknemerSalarisVerhoogtMetTweeJaren()
        {
            Werknemer target = new Werknemer(naam: "Jan", leeftijd: 40, salaris: 1000.00M);

            target.Leeftijd += 2;

            Assert.AreEqual(1020.10M, target.Salaris);
        }

        [TestMethod]
        public void WerknemerSalarisVerlaagtMetTweeJaren()
        {
            Thread.Sleep(100);
            Werknemer target = new Werknemer(naam: "Jan", leeftijd: 40, salaris: 1000.00M);

            target.Leeftijd -= 2;

            Assert.AreEqual(980.30M, target.Salaris);
        }
    }
}
