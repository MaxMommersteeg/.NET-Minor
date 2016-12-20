using Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Test.Validators
{
    [TestClass]
    public class VoertuigTypeValidatorAttributeTest
    {
        [TestMethod]
        public void IsValidWithValidVoertuigTypeReturnsTrue()
        {
            // Arrange
            string voertuigType = "personenauto";
            VoertuigTypeValidatorAttribute voertuigTypeValidatorAttribute = new VoertuigTypeValidatorAttribute("Error message", new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" });
            
            // Act
            bool result = voertuigTypeValidatorAttribute.IsValid(voertuigType);
            
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidWithInvalidVoertuigTypeReturnsFalse()
        {
            // Arrange
            string voertuigType = "auto";
            VoertuigTypeValidatorAttribute voertuigTypeValidatorAttribute = new VoertuigTypeValidatorAttribute("Error message", new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" });

            // Act
            bool result = voertuigTypeValidatorAttribute.IsValid(voertuigType);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidWithNullReturnsFalse()
        {
            // Arrange
            string voertuigType = null;
            VoertuigTypeValidatorAttribute voertuigTypeValidatorAttribute = new VoertuigTypeValidatorAttribute("Error message", new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" });

            // Act
            bool result = voertuigTypeValidatorAttribute.IsValid(voertuigType);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
