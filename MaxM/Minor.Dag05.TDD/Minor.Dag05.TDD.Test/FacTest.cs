using System;
using Xunit;

namespace Minor.Dag05.TDD.Test {
    public class FacTest
    {
        [Fact]
        public void Faculty1is1() {
            // Arrange
            var target = new Faculty();

            // Act
            var result = target.CalculateFaculty(1);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Faculty8is40320() {
            // Arrange
            var target = new Faculty();

            // Act
            var result = target.CalculateFaculty(8);

            // Assert
            Assert.Equal(40320, result);
        }

        [Fact]
        public void Faculty7is() {
            // Arrange
            var target = new Faculty();

            // Act
            var result = target.CalculateFaculty(7);

            // Assert
            Assert.Equal(5040, result);
        }
    }
}
