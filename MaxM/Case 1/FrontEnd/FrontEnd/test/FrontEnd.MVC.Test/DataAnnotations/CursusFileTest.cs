using FrontEnd.DataAnnotations;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace FrontEnd.MVC.Test.DataAnnotations
{
    [TestClass]
    public class CursusFileTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void NoFileReturnsInvalid()
        {
            // Arrange
            var cursusFile = new CursusFile();

            // Act
            var result = cursusFile.IsValid(null);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidObjectReturnsInvalid()
        {
            // Arrange
            var cursusFile = new CursusFile();

            // Act
            var result = cursusFile.IsValid(new DateTime());

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidFileReturnsInvalid()
        {
            // Arrange
            var cursusFile = new CursusFile();
            var formFile = new FormFile(null, 0, 0, "Excelfile", "Excelfile.xlsx");

            // Act
            var result = cursusFile.IsValid(formFile);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidButEmptyFileReturnsInvalid()
        {
            // Arrange
            var cursusFile = new CursusFile();
            byte[] fileContents = Encoding.UTF8.GetBytes("TestFile");
            var formFile = new FormFile(new MemoryStream(fileContents), 0, 0, "TextFile", "TextFile.txt");

            // Act
            var result = cursusFile.IsValid(formFile);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
