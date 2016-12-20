using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.Validators {
    [TestClass]
    public class DateValidationTest
    {
        /// <summary>
        /// InvalidDateReturnsFalse
        /// </summary>
        [TestMethod]
        public void InvalidDateReturnsFalse()
        {
            // Arrange
            var invalidDate = new DateTime();
            var validator = new DateValidator();

            // Act
            var result = validator.IsValid(invalidDate);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// ValidDateReturnsTrue
        /// </summary>
        [TestMethod]
        public void ValidDateReturnsTrue() 
        {
            // Arrange
            var validDate = new DateTime(2016, 10, 10);
            var validator = new DateValidator();

            // Act
            var result = validator.IsValid(validDate);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
