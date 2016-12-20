using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.ResultModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Test.ResultModels 
{
    [TestClass]
    public class ValidRequestTest
    {
        [TestMethod]
        public void ValidRequestConstructorTest() 
        {
            // Arrange - Act
            var target = new ValidRequest();

            // Assert
            Assert.IsNotNull(target);
        }
    }
}
