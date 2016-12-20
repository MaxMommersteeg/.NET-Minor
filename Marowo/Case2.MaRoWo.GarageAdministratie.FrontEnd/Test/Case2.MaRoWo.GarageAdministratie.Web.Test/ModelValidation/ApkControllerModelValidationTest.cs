using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.ModelValidation 
{
    [TestClass]
    public class ApkControllerModelValidationTest
    {
        [TestMethod]
        public void EmptyInvalidModelModelStateFalse() 
        {
            // Arrange
            var model = new ApkAanvraagViewModel();
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
            var model = new ApkAanvraagViewModel 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = -1,
                EigenaarAuto = "Max",
                VoertuigType = "personenauto"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void InvalidVoertuigTypeModelStateFalse() 
        {
            // Arrange
            var model = new ApkAanvraagViewModel 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = 100,
                EigenaarAuto = "Max",
                VoertuigType = "motorboot"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void InvalidKentekenModelStateFalse() 
        {
            // Arrange
            var defaultApkAanvraag = new ApkAanvraagViewModel 
            {
                Kenteken = "",
                Kilometerstand = 100,
                EigenaarAuto = "Max",
                VoertuigType = "personenauto"
            };
            var context = new ValidationContext(defaultApkAanvraag, null, null);
            var results = new List<ValidationResult>();

            // Act
            var modelStateIsValid = Validator.TryValidateObject(defaultApkAanvraag, context, results, true);

            // Assert
            Assert.IsFalse(modelStateIsValid);
        }

        [TestMethod]
        public void ValidKentekensTrue() 
        {
            // Arrange
            var invalidKentekens = new[] { "11-AA-BB", "01-02-AA", "01-BBB-ZZ", "01-A-BZA" };
            var defaultApkAanvraag = new ApkAanvraagViewModel 
            {
                Kilometerstand = 100,
                EigenaarAuto = "Max",
                VoertuigType = "personenauto"
            };
            bool modelStateIsValid = true;

            // Act
            foreach (var invalidKenteken in invalidKentekens) 
            {
                // Update to new faulty kenteken
                defaultApkAanvraag.Kenteken = invalidKenteken;
                var context = new ValidationContext(defaultApkAanvraag, null, null);
                var results = new List<ValidationResult>();
                var isModelStateValid = Validator.TryValidateObject(defaultApkAanvraag, context, results, true);
                if (!isModelStateValid) 
                {
                    modelStateIsValid = false;
                    break;
                }
            }
            // Assert
            Assert.IsTrue(modelStateIsValid);
        }

        [TestMethod]
        public void InvalidTooShortEigenaarAutoModelStateFalse() 
        {
            // Arrange
            var model = new ApkAanvraagViewModel 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = 100,
                EigenaarAuto = "Jo",
                VoertuigType = "personenauto"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void ValidModelModelStateTrue() 
        {
            // Arrange
            var model = new ApkAanvraagViewModel 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = 100,
                EigenaarAuto = "Max",
                VoertuigType = "personenauto"
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
