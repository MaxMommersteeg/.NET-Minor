using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag18.MonumentenSite.Controllers;
using Minor.Dag18.MonumentenSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag18.MonumentenSite.Test
{
    [TestClass]
    public class MonumentControllerTest
    {
        [TestMethod]
        public void MonumentWithoutRequiredNameReturnsView()
        {
            // Arrange
            var mock = new MonumentenContextMock();
            var target = new MonumentController(mock);
            var invalidmonument = new Monument { Naam = null, Stad = "Berlin" };
            // Act
            IActionResult result = target.Create(invalidmonument);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
