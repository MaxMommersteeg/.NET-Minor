using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventOefenen;

namespace EventTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void PersoonAanmakenTest()
        {
            //Arrange
            LeeftijdChange marco = new LeeftijdChange("marco",40);

            //Act


            //Assert
            Assert.AreEqual( "marco",marco.Naam);
            Assert.AreEqual(40, marco.Leeftijd);

        }

        [TestMethod]
        public void PersoonLeeftijdChangeEventToevoegenTest()
        {
            //Arrange
            var marco = new LeeftijdChange("Marco",40);
            var listenerMock = new ListenerMock();
            marco.LeeftijdChanged += listenerMock.LeeftijdChanged;
            //Act
            marco.verjaar(25);

            //Assert
            Assert.IsTrue(listenerMock.LeeftijdChangedHasBeenCalled);
        }

        [TestMethod]
        public void PersoonLeeftijdChangeEventVerwijderenTest()
        {
            //Arrange
            var marco = new LeeftijdChange();
            var listenerMock = new ListenerMock();
            marco.LeeftijdChanged += listenerMock.LeeftijdChanged;
            //Act
            marco.LeeftijdChanged -= listenerMock.LeeftijdChanged;
            marco.verjaar(25);

            //Assert
            Assert.IsFalse(listenerMock.LeeftijdChangedHasBeenCalled);
        }

        [TestMethod]
        public void PersoonLeeftijdStellenEventTest()
        {
            //Arrange
            var marco = new LeeftijdChange();
            var listenerMock = new ListenerMock();
            marco.LeeftijdChanged += listenerMock.LeeftijdChanged;
            //Act
            marco.verjaar(25);

            //Assert
            Assert.AreEqual(25,listenerMock.LeeftijdChangedEventArgs.Leeftijd);
        }

        [TestMethod]
        public void PersoonLeeftijdPlus1EventTest()
        {
            //Arrange
            var marco = new LeeftijdChange();
            var listenerMock = new ListenerMock();
            marco.LeeftijdChanged += listenerMock.LeeftijdChanged;
            //Act
            marco.verjaar();

            //Assert
            Assert.AreEqual(1, listenerMock.LeeftijdChangedEventArgs.Leeftijd);
        }

        [TestMethod]
        public void PersoonSetLeeftijdPlus1EventTest()
        {
            //Arrange
            var marco = new LeeftijdChange("Macro",40);
            var listenerMock = new ListenerMock();
            marco.LeeftijdChanged += listenerMock.LeeftijdChanged;
            //Act
            marco.verjaar();

            //Assert
            Assert.AreEqual(41, listenerMock.LeeftijdChangedEventArgs.Leeftijd);
        }





    }
}
