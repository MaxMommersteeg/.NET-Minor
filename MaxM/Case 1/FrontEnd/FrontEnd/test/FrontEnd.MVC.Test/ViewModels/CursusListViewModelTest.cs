using FrontEnd.Agents.Models;
using FrontEnd.ViewModels.Cursus;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FrontEnd.MVC.Test.ViewModels
{
    [TestClass]
    public class CursusListViewModelTest
    {
        [TestMethod]
        public void CursusListViewModelInitializationIsCorrect()
        {
            // Arrange
            var target = new CursusListViewModel();

            // Act - Assert
            Assert.AreNotEqual(null, target.Years);
            Assert.AreNotEqual(null, target.WeekNumbers);
            Assert.AreNotEqual(null, target.Cursussen);

            Assert.IsInstanceOfType(target.Years, typeof(IEnumerable<SelectListItem>));
            Assert.IsInstanceOfType(target.WeekNumbers, typeof(IEnumerable<SelectListItem>));
            Assert.IsInstanceOfType(target.Cursussen, typeof(List<CursusViewModel>));

            Assert.IsTrue(target.Years.First().Value == "1980");
            Assert.IsTrue(target.Years.First().Text == "1980");

            Assert.IsTrue(target.WeekNumbers.First().Value == "1");
            Assert.IsTrue(target.WeekNumbers.First().Text == "1");
            Assert.IsTrue(target.WeekNumbers.Last().Value == "53");
            Assert.IsTrue(target.WeekNumbers.Last().Text == "53");

            Assert.IsTrue(target.Cursussen.FirstOrDefault() == null);
        }
    }
}
