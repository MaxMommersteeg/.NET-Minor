using Case2.MaRoWo.RDW.IntegrationService.Facade.Controllers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.RDW.IntegrationService.Facade.Test.ModelValidation 
{
    [TestClass]
    public class ApkControllerModelValidationTest
    {
        [TestMethod]
        public void EmptyInvalidModelModelStateFalse() 
        {
            // Arrange
            var model = new ApkKeuringsVerzoekCommand();
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void UnderZeroKilometerstandModelStateFalse() 
        {
            // Arrange
            var model = new ApkKeuringsVerzoekCommand 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = -1,
                EigenaarNaam = "Max",
                VoertuigType = "Personenauto",
                KeuringsDatum = DateTime.Now.Date,
                KeuringsinstantieKvkNummer = "19283746501",
                KeuringsinstantieType = "apk",
                Bedrijfsnaam = "MaRoWo",
                BedrijfPlaats = "Utrecht"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void ValidApkKeuringsVerzoekCommandModelStateTrue() 
        {
            // Arrange
            var model = new ApkKeuringsVerzoekCommand 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = 200,
                EigenaarNaam = "Max",
                VoertuigType = "Personenauto",
                KeuringsDatum = DateTime.Now.Date,
                KeuringsinstantieKvkNummer = "19283746501",
                KeuringsinstantieType = "apk",
                Bedrijfsnaam = "MaRoWo",
                BedrijfPlaats = "Utrecht"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsTrue(isModelStateValid);
        }
    }
}
