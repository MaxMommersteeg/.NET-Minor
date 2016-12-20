using FrontEnd.ViewModels.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrontEnd.MVC.Test.ViewModels
{
    [TestClass]
    public class PageHeaderViewModelTest
    {
        [TestMethod]
        public void PageHeaderViewModelSetValuesAreCorrect()
        {
            // Arrange
            string title = "TitleText";
            string description = "DescriptionText";
            var target = new PageHeaderViewModel(title, description);

            // Act and Assert
            Assert.AreNotEqual(null, target);
            Assert.AreEqual(title, target.Title);
            Assert.AreEqual(description, target.Description);
        }
    }
}
