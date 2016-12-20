using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MicroTest
{
    public class MicroTest
    {
        [Fact]
        public void KaartAanmakenTest()
        {
            //Act
            Kaart kaart = new Kaart(50.0M);

            //Assert
            Assert.Equal(50.0M, kaart.getSaldo());
        }

        [Fact]
        public void KaartBetaalTest()
        {
            //arrange
            Kaart kaart = new Kaart(50.0M);

            //act
            kaart.Betaal(10M);
            decimal result = kaart.getSaldo();

            //Assert
            Assert.Equal(40.0M, result);
        }

        [Fact]
        public void KaartBetaalNormaalTest()
        {
            //arrange
            Kaart kaart = new Normaal(50.0M);

            //act & Assert
            Assert.Throws<InvalidOperationException>(() => kaart.Betaal(60M));

        }

        [Fact]
        public void KaartKortingVIPTest()
        {
            //arrange
            Kaart kaart = new VIP(50.0M, 10);

            //act
            kaart.Betaal(10M);
            decimal result = kaart.getSaldo();

            //Assert
            Assert.Equal(41.0M, result);
        }

        [Fact]
        public void KaartSaldoReadTest()
        {
            //arrange
            Kaart kaart = new Kaart(50.0M);

            //act

            decimal result = kaart.getSaldo();

            //Assert
            Assert.Equal(50.0M, result);
        }

    }
}
