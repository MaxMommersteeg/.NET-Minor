using FE.Agents;
using FE.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Test
{
    [TestClass]
    public class KoffieAgentTest
    {
        private IKoffieAgent _koffieAgent;

        [TestInitialize]
        public void InitializeTest()
        {
            _koffieAgent = new KoffieAgent();
        }

        [TestMethod]
        public void TestKoffieAddCount()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 8, Naam = "Cappuccino", MinimaleInhoudInCl = 12, MaximaleInhoudInCl = 25 };

            // Act
            _koffieAgent.Add(newKoffie);

            // Assert
            Assert.AreEqual(3, _koffieAgent.GetAll().Count());
        }

        [TestMethod]
        public void TestKoffieAddContents()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 8, Naam = "Cappuccino", MinimaleInhoudInCl = 12, MaximaleInhoudInCl = 25 };

            // Act
            _koffieAgent.Add(newKoffie);

            // Assert
            var result = _koffieAgent.GetAll().Last();
            Assert.AreEqual(newKoffie, result);
        }

        [TestMethod]
        public void TestKoffieAddNull()
        {
            // Arrange
            Koffie newKoffie = null;

            // Act
            Action actionResult = () => _koffieAgent.Add(newKoffie);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(actionResult);
        }

        [TestMethod]
        public void TestKoffieAddSameIdentifier()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 1, Naam = "Cappuccino", MinimaleInhoudInCl = 12, MaximaleInhoudInCl = 25 };

            // Act
            Action actionResult = () => _koffieAgent.Add(newKoffie);

            // Assert
            Assert.ThrowsException<ArgumentException>(actionResult);
        }

        [TestMethod]
        public void TestKoffieDeleteNotExistingIdentifier()
        {
            // Arrange
            var koffieId = -10;

            // Act
            Action actionResult = () => _koffieAgent.Delete(koffieId);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(actionResult);
        }

        [TestMethod]
        public void TestKoffieDeleteCountItems()
        {
            // Arrange
            var koffieId = 1;

            // Act
            _koffieAgent.Delete(koffieId);
            var result = _koffieAgent.GetAll().Count();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestKoffieDeleteMultipleItemsCount()
        {
            // Arrange
            var koffieId1 = 1;
            var koffieId2 = 2;

            // Act
            _koffieAgent.Delete(koffieId1);
            _koffieAgent.Delete(koffieId2);
            var result = _koffieAgent.GetAll().Count();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestKoffieAgentGetById()
        {
            // Arrange
            var koffieId = 1;

            // Act
            var result = _koffieAgent.GetById(koffieId);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void TestKoffieAgentNewKoffieById()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 16, Naam = "Latte Machiato", MinimaleInhoudInCl = 12, MaximaleInhoudInCl = 25 };

            // Act
            _koffieAgent.Add(newKoffie);
            var result = _koffieAgent.GetById(newKoffie.Id);

            // Assert
            Assert.AreEqual(16, result.Id);
            Assert.AreEqual("Latte Machiato", result.Naam);
            Assert.AreEqual(12, result.MinimaleInhoudInCl);
            Assert.AreEqual(25, result.MaximaleInhoudInCl);
        }
    }
}
