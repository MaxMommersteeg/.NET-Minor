using FrontEnd.Extensions;
using FrontEnd.MVC.Test.Mocks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrontEnd.MVC.Test.Extensions
{
    [TestClass]
    public class MvcHtmlExtensionsTest
    {
        [TestMethod]
        public void DateForFormatValid1Test()
        {
            // Arrange
            IHtmlHelper helper = null;
            var date = new DateTime(2016, 10, 11);

            // Act
            var result = helper.DateForFormat(date, DateFormats.ddMMyyyy);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.IsTrue(result.ToString() == "11-10-2016");
        }

        [TestMethod]
        public void DateForFormatValid2Test()
        {
            // Arrange
            IHtmlHelper helper = null;
            DateTime date = new DateTime(2016, 10, 11, 12, 13, 14);

            // Act
            var result = helper.DateForFormat(date, DateFormats.ddMMyyyy);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.IsTrue(result.ToString() == "11-10-2016");
        }
    }
}
