using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Test.Commands
{
    [TestClass]
    public class UpdateOnderhoudCommandModelValidation
    {
        [TestMethod]
        public void EmptyModelModelStateFalse()
        {
            // Arrange
            var model = new UpdateOnderhoudCommand();
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            // Act
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void UnderZeroKilometerstandModelModelStateFalse()
        {
            // Arrange
            var model = new UpdateOnderhoudCommand
            {
                OnderhoudsId = 1,
                Kenteken = "11-AA-22",
                Kilometerstand = -1,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow,
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
            var model = new UpdateOnderhoudCommand
            {
                OnderhoudsId = 1,
                Kenteken = "11-AA-22",
                Kilometerstand = 3600,
                OnderhoudsBeschrijving = "Max",
                HasApk = true,
                OpdrachtAangemaakt = DateTime.UtcNow
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
