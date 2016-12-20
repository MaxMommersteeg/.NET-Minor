using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFSBuild.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestNothing()
        {
            // Arrange
            var val1 = 1;
            var val2 = 1;

            // Act
            var result = val1 + val2;

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
