using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.Validators 
{
    [TestClass]
    public class VoertuigTypeValidatorTest
    {
        [TestMethod]
        public void IsValidWithValidVoertuigTypeReturnsTrue() 
        {
            // Arrange
            var validVoertuigTypes = new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" };
            var target = new VoertuigTypeValidator();

            // Act
            var result = false;
            foreach(var voertuigType in validVoertuigTypes) 
            {
                result = target.IsValid(voertuigType);
                if(!result) 
                {
                    break;
                }
            }

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidWithNullReturnsFalse() 
        {
            // Arrange
            string invalidVoertuigType = null;
            var target = new VoertuigTypeValidator();

            // Act
            var result = target.IsValid(invalidVoertuigType);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
