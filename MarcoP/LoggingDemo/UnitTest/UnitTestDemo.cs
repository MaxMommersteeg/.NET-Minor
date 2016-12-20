using LoggingDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {

            // Arrange
            var controller = new LoggingDemo.Controllers.HomeController();

            // Act
            var result = controller.Index();
            var view = ((ViewResult)result);
            var vm = ((MinorViewModel)view.Model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Sander", vm.Docent);

        }
    }
}
