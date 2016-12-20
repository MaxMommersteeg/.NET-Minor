using Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Test.Validators
{
    [TestClass]
    public class DateValidatorAttributeTest
    {
        [TestMethod]
        public void IsValidWithValidDateReturnsTrue()
        {
            // Arrange
            DateTime date = DateTime.Now.Date;
            DateValidatorAttribute dateValidatorAttribute = new DateValidatorAttribute();
            // Act
            bool result = dateValidatorAttribute.IsValid(date);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidWithDateInFutureReturnsFalse()
        {
            // Arrange
            double extraDays = 1;
            DateTime date = DateTime.Now.AddDays(extraDays).Date ;
            DateValidatorAttribute dateValidatorAttribute = new DateValidatorAttribute();
            // Act
            bool result = dateValidatorAttribute.IsValid(date);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidWithDateInPastReturnsFalse()
        {
            // Arrange
            double minusDays = -1;
            DateTime date = DateTime.Now.AddDays(minusDays).Date;
            DateValidatorAttribute dateValidatorAttribute = new DateValidatorAttribute();
            // Act
            bool result = dateValidatorAttribute.IsValid(date);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidWithEmptyDateReturnsFalse()
        {
            // Arrange
            DateTime date = new DateTime();
            DateValidatorAttribute dateValidatorAttribute = new DateValidatorAttribute();
            // Act
            bool result = dateValidatorAttribute.IsValid(date);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidWithValidDateWithTimeReturnsTrue()
        {
            // Arrange
            DateTime date = DateTime.Now;
            DateValidatorAttribute dateValidatorAttribute = new DateValidatorAttribute();
            // Act
            bool result = dateValidatorAttribute.IsValid(date);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
