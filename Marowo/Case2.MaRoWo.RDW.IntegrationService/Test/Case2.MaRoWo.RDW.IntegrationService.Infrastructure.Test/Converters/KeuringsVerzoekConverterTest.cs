using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.Converters {
    [TestClass]
    public class KeuringsVerzoekConverterTest
    {
        [TestMethod]
        public void ToKeuringsVerzoekAntwoordWithNullParamThrows() 
        {
            // Arrange
            var target = new KeuringsVerzoekConverter();
            Keuringsregistratie invalidKeuringsregistratie = null;

            // Act - Assert
            Assert.ThrowsException<ArgumentNullException>(() => target.ToKeuringsVerzoekAntwoord(invalidKeuringsregistratie));
        }

        [TestMethod]
        public void ToKeuringsVerzoekAntwoordNullSteekproefThrows() 
        {
            // Arrange
            var target = new KeuringsVerzoekConverter();
            var invalidKeuringsRegistratie = new Keuringsregistratie() 
            {
                Steekproef = null
            };

            // Act - Assert
            Assert.ThrowsException<ArgumentNullException>(() => target.ToKeuringsVerzoekAntwoord(invalidKeuringsRegistratie));
        } 

        [TestMethod]
        public void ToKeuringsVerzoekAntwoordNilTrueIssteekproefFalseDateNull() 
        {
            // Arrange
            var target = new KeuringsVerzoekConverter();
            var keuringsRegistratie = new Keuringsregistratie() 
            {
                Steekproef = new Steekproef { Nil = "true" }
            };

            // Act
            var result = target.ToKeuringsVerzoekAntwoord(keuringsRegistratie);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSteekProef);
            Assert.IsNull(result.SteepkProefDate);
        }

        [TestMethod]
        public void ToKeuringsVerzoekAntwoordNilNullIssteekproefTrueDateNotNull() 
        {
            // Arrange
            var target = new KeuringsVerzoekConverter();
            var keuringsRegistratie = new Keuringsregistratie() 
            {
                Steekproef = new Steekproef 
                {
                    Nil = null,
                    Text = DateTime.Now.ToString("dd-MM-yyyy")
                }
            };

            // Act
            var result = target.ToKeuringsVerzoekAntwoord(keuringsRegistratie);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSteekProef);
            Assert.IsNotNull(result.SteepkProefDate);
        }

        [TestMethod]
        public void ToKeuringsVerzoekAntwoordSteekproefInvalidDateDateNull() 
        {
            // Arrange
            var target = new KeuringsVerzoekConverter();
            var keuringsRegistratie = new Keuringsregistratie() 
            {
                Steekproef = new Steekproef 
                {
                    Nil = null,
                    Text = null
                }
            };

            // Act
            var result = target.ToKeuringsVerzoekAntwoord(keuringsRegistratie);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSteekProef);
            Assert.IsNull(result.SteepkProefDate);
        }
    }
}
