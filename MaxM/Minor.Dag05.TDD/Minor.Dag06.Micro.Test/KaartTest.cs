using System;
using System.Diagnostics;
using Xunit;

namespace Minor.Dag06.Micro.Test {
    public class KaartTest
    {
        
        [Fact]
        public void NormaleKaartNietRoodBetalen() {
            // Arrange
            var saldoNegative = true;
            var bedrag = 20.0M;

            // Act
            try {
                Kaart target = new NormaleKaart(-10.0M);
                target.Betalen(bedrag);
                saldoNegative = false;
            } catch (ArgumentOutOfRangeException aoore) {
                Debug.WriteLine(aoore);
                saldoNegative = true;
            }

            // Assert
            Assert.Equal(true, saldoNegative);
        }

        [Fact]
        public void VipKaartSaldoWithKorting() {
            // Arrange
            var target = new VipKaart(10.0M, 5);
            var bedrag = 10.0M;

            // Act
            target.Betalen(bedrag);

            // Assert
            Assert.Equal(0.5M, target.Saldo);
        }

        [Fact]
        public void NormaleKaartMetNegatiefSaldoAanmaken() {
            var gotError = false;

            // Act
            try {
                // Arrange
                var target = new NormaleKaart(-10.0M);
                gotError = false;
            } catch (ArgumentOutOfRangeException aoore) {
                Debug.WriteLine(aoore);
                gotError = true;
            }
            // Assert
            Assert.Equal(true, gotError);
        }

    }
}
