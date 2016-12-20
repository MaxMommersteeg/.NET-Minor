using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.ResultModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Test.ResultModels 
{

    [TestClass]
    public class InvalidRequestTest
    {
        [TestMethod]
        public void InvalidRequestConstructorTest() 
        {
            // Arrange
            var expectedMessage = "InvalidRequestMessage";
            var expectedInvalidProperties = new List<string> { "InvalidProperty1", "InvalidProperty2" };

            // Act
            var target = new InvalidRequest(expectedMessage, expectedInvalidProperties);

            // Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(expectedMessage, target.Message);
            CollectionAssert.AreEqual(expectedInvalidProperties, target.InvalidProperties.ToList());
        }
    }
}
