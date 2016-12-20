using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Test.Statussen 
{
    [TestClass]
    public class OpdrachtStatusTest
    {
        [TestMethod]
        public void OpdrachtStatusConstructorTest() 
        {
            // Arrange
            var expectedStatusId = 1;
            var expectedBeschrijving = "Aangemeld";

            // Act
            var opdrachtStatus = new OpdrachtStatus(expectedStatusId, expectedBeschrijving);

            // Assert
            Assert.IsNotNull(opdrachtStatus);
            Assert.AreEqual(expectedStatusId, opdrachtStatus.StatusId);
            Assert.AreEqual(expectedBeschrijving, opdrachtStatus.Beschrijving);
        }
    }
}
