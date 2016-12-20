using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag06.MicroOefening.Test
{
    [TestClass]
    public class KaartTest
    {
        [TestMethod]
        public void NieuwKaartTest()
        {
            // Act
            Kaart kaart = new Kaart(100.00M);

            // Assert
            Assert.AreEqual(100.00M, kaart.Saldo);
        }

        [TestMethod]
        public void Betaal50Test()
        {
            // Arrange
            Kaart kaart = new Kaart(100.00M);

            // Act
            kaart.Betaal(50.00M);

            // Assert
            Assert.AreEqual(50.00M, kaart.Saldo);
        }

        [TestMethod]
        public void Betaal30MetNormaleKaartTest()
        {
            // Arrange
            Kaart kaart = new NormaleKaart(100.00M);

            // Act
            kaart.Betaal(30.00M);

            // Assert
            Assert.AreEqual(70.00M, kaart.Saldo);
        }

        [TestMethod]
        public void Betaal130MetNormaleKaartTest()
        {
            // Arrange
            Kaart kaart = new NormaleKaart(100.00M);

            // Act
            Action action = () => kaart.Betaal(130.00M);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Betaal50MetVIPKaartTest()
        {
            // Arrange
            Kaart kaart = new VIPkaart(100.00M, kortingspercentage: 10.0M);

            // Act
            kaart.Betaal(50.00M);

            // Assert
            Assert.AreEqual(55.00M, kaart.Saldo);
        }

        [TestMethod]
        public void Betaal200MetVIPKaartTest()
        {
            // Arrange
            Kaart kaart = new VIPkaart(100.00M, kortingspercentage: 10.0M);

            // Act
            kaart.Betaal(200.00M);

            // Assert
            Assert.AreEqual(-80.00M, kaart.Saldo);
        }


        [TestMethod]
        public void Betaal_min10MetVIPKaartTest()
        {
            // Arrange
            Kaart kaart = new VIPkaart(100.00M, kortingspercentage: 10.0M);

            // Act
            Action action = () => kaart.Betaal(-10.00M);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(action);
        }

    }
}
