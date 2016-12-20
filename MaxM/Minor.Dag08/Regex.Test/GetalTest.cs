using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Regex.Test
{
    [TestClass]
    public class GetalTest
    {

        [TestMethod]
        public void ControleerStreepjeBegin()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-12.00");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ControleerGeenStreepjeBegin()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("12.00");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ControleerCijfersEnKommasGeldig1()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-1,2,3,523,2,12.22");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ControleerCijfersEnKommasGeldig2()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("1,2,3,523,2,12.22");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ControleerCijfersEnKommasOngeldig1()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-1,2_3,523,2,12.12");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ControleerCijfersEnKommasOngeldig2()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-1,2.3,523,2,12.12");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Einde2CijfersGeldig()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-1,231,123,122.22");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Einde2CijfersOngeldig()
        {
            // Arrange
            var target = new GetalChecker();

            // Act
            bool result = target.Check("-1,23,1,12,22AA");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
