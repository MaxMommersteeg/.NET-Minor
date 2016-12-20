using Xunit;

namespace Minor.Dag05.TDD.Test {
    public class DoubleTest
    {
        [Fact]
        public void FindSmallestDouble() {
            // Arrange
            var target = new Doubling();

            // Act
            var result = target.FindStrangeDouble();

            // Assert
            Assert.True(result == result + 1);
        }

        [Fact]
        public void FindSmallestDoubleTest() {
            // Arrange
            var target = new Doubling();

            // Act
            var result = target.FindStrangeDouble();

            // Assert
            Assert.True(result > 0);
        }
    }
}
