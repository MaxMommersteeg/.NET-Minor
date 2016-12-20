using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace minor.dag05.fac.test
{
    public class DoubleTest
    {
        [Fact]
        public void DoubleRaarTest()
        {
            //Arrange
            var target = new Double2();

            //Act
            double result = target.FindStrangeAnyDouble();

            //Assert
            Assert.True(result == result+1);
        }

        [Fact]
        public void DoubleRaarLowTest()
        {
            //Arrange
            var target = new Double2();

            //Act
            double result = target.FindStrangeLowDouble();

            //Assert
            Assert.True(result>0);
            Assert.True(result == result + 1);
            Assert.True(result < 1e30);


        }

    }
}
