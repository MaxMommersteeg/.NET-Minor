using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Minor.Dag05.MarcoMath.Test
{
    public class MathTest
    {
        [Fact]
        public void Fib1is1Test()
        {
            // Arrange
            var target = new Math();

            // Act
            int result = target.Fib(1);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Fib3is2Test()
        {
            // Arrange
            var target = new Math();

            // Act
            int result = target.Fib(3);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Fib4is3Test()
        {
            // Arrange
            var target = new Math();

            // Act
            int result = target.Fib(4);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Fib0ThrowsInvalidOperationException()
        {
            // Arrange
            var target = new Math();

            // Act
            Exception ex = Assert.Throws<InvalidOperationException>(() => target.Fib(0));

            // Assert
            Assert.Equal("Cannot compute Fib(0)", ex.Message);
        }

        [Fact]
        public void Week41In2016Zou10OktoberMoetenOpleveren()
        {
            var date = LocalDate.FromWeekYearWeekAndDay(2016, 41, IsoDayOfWeek.Monday);
            var expected = LocalDate.FromDateTime(new DateTime(2016, 10, 10));
            
            Assert.Equal(expected, date);
        }
    }
}
