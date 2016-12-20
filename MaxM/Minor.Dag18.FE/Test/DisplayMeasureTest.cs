using FE.Agents;
using FE.HtmlHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class DisplayMeasureTest
    {
        private IKoffieAgent _koffieAgent;

        [TestInitialize]
        public void InitializeTest()
        {
            
        }

        [TestMethod]
        public void TestDisplayMeasureCLSuffix()
        {
            // Arrange
            var minimaleInhoudCl = 25;

            // Act
            var result = DisplayMeasure.DisplayCL(null, minimaleInhoudCl);

            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(string));
            Assert.IsTrue(result.Value.Contains("CL"));
            Assert.IsTrue(result.Value.Substring(result.Value.Length - 2, 2) == "CL");
        }
    }
}
