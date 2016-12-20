using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using minor.dag05.fac;

namespace minor.dag05.fac.test
{
    public class FacTest
    {
        [Fact]
        public void FacTest1is1 ()
        {
            //Arrange
            var target = new Fac();

            //Act
            int result = target.Fact(1);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void FacTest2is2()
        {
            //Arrange
            var target = new Fac();

            //Act
            int result = target.Fact(2);

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void FacTest3is6()
        {
            //Arrange
            var target = new Fac();

            //Act
            int result = target.Fact(3);

            //Assert
            Assert.Equal(6, result);
        }


        [Fact]

        public void FacTest0isException()
        {
            //Arrange
            var target = new Fac();

            //Act
            Assert.Throws<InvalidOperationException>(() => target.Fact(0)) ;
           // int result = target.Fact(0);

            //Assert
            //Assert.Throws<InvalidOperationException>result;
        }

    }
}
