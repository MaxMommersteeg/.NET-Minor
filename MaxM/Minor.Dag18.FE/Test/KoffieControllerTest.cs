using FE.Agents;
using FE.Controllers;
using FE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.AgentMock;

namespace Test
{
    [TestClass]
    public class KoffieControllerTest
    {
        private IKoffieAgent _koffieAgent;

        [TestInitialize]
        public void InitializeTest()
        {
            _koffieAgent = new DummyKoffieAgent();
        }

        [TestMethod]
        public void TestErrorResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult result = target.Error();

            // Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void TestIndexResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult result = target.Index();

            // Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void TestIndexModelResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Index();
            var result = (actionResult as ViewResult).Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Koffie>));
        }

        [TestMethod]
        public void TestIndexModelListCount()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Index();
            var model = (actionResult as ViewResult).Model;
            var result = (model as IEnumerable<Koffie>);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Koffie>));
            Assert.AreEqual(result.Count(), _koffieAgent.GetAll().Count());
        }

        [TestMethod]
        public void TestIndexModelListContent()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Index();
            var model = (actionResult as ViewResult).Model;
            var result = (model as IEnumerable<Koffie>);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Koffie>));
            Assert.AreEqual(_koffieAgent.GetAll().FirstOrDefault(), result.FirstOrDefault());
        }

        [TestMethod]
        public void TestDetailsResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult result = target.Details(1);

            // Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void TestDetailsModelResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Details(1);
            var result = (actionResult as ViewResult).Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Koffie));
        }

        [TestMethod]
        public void TestDetailsModelContents()
        {
            // Arrange
            var koffieId = 1;
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Details(koffieId);
            var result = (actionResult as ViewResult).Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Koffie));

            Assert.AreEqual(result, _koffieAgent.GetById(koffieId));
        }

        [TestMethod]
        public void TestDetailsModelNullKoffie()
        {
            // Arrange
            var koffieId = -30;
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult actionResult = target.Details(koffieId);
            var result = (actionResult as ViewResult).Model;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestDeleteResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult result = target.Delete(1);

            // Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void TestAddResult()
        {
            // Arrange
            var target = new KoffieController(_koffieAgent);

            // Act
            IActionResult result = target.Add();

            // Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

    }
}
