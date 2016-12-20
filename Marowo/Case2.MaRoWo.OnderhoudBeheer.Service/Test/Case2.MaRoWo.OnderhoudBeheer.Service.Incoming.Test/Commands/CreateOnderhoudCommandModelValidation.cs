using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Test.Commands 
{
    [TestClass]
    public class CreateOnderhoudCommandModelValidation
    {
        [TestMethod]
        public void EmptyInvalidModelModelStateFalse() 
        {
            // Arrange
            var model = new CreateOnderhoudCommand();
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
            var model = new CreateOnderhoudCommand 
            {
                Kenteken = "11-AA-22",
                Kilometerstand = -1,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow,
                Bestuurder = "Rob",
                TelefoonNrBestuurder = "06-123456789"
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
            var model = new CreateOnderhoudCommand 
            {
                Kenteken = "ZZ-01-HH",
                Kilometerstand = 3600,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow,
                Bestuurder = "Rob",
                TelefoonNrBestuurder = "06-123456789"
                
            };
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

          
            // Assert
            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void ValidModelModelKentekenStateFalse()
        {
            // Arrange
            var model = new CreateOnderhoudCommand
            {
                // lengt is 51
                Kenteken = "ZZ-01-HH-1ZZ-01-HH-1ZZ-01-HH-1ZZ-01-HH-1ZZ-01123456",
                Kilometerstand = 3600,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow,
                Bestuurder = "Rob",
                TelefoonNrBestuurder = "06-123456789"

            };
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

        

            // act
          
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);


            // Assert
            Assert.AreEqual(51, model.Kenteken.Length);
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void ValidModelModelKentekenStateTrue()
        {
            // Arrange
            var model = new CreateOnderhoudCommand
            {
                // lengt is 50
                Kenteken = "ZZ-01-HH-1ZZ-01-HH-1ZZ-01-HH-1ZZ-01-HH-1ZZ-2011234",
                Kilometerstand = 3600,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow,
                Bestuurder = "Rob",
                TelefoonNrBestuurder = "06-123456789"

            };
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);


            // Assert
            Assert.AreEqual(50, model.Kenteken.Length);
            Assert.IsTrue(isModelStateValid);
        }
    }
}
