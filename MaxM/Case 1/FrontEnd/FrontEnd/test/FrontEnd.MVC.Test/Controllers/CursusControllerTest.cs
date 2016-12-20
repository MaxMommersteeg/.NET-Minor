using FrontEnd.Agents;
using FrontEnd.Agents.Models;
using FrontEnd.Controllers;
using FrontEnd.MVC.Test.Mocks;
using FrontEnd.Parsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.MVC.Test
{
    [TestClass]
    public class CursusControllerTest
    {
        private ICASService _casService;
        private ICursusFileParser _cursusFileParser;

        [TestInitialize]
        public void Initialize()
        {
            _casService = new CASServiceMock();
            _cursusFileParser = new CursusFileParser(_casService);
        }

        [TestMethod]
        public void IndexReturnsCorrectIActionResult()
        {
            // Arrange
            int year = 2014;
            int weeknumber = 42;

            CursusController cursusController = new CursusController(_casService, _cursusFileParser);

            // Act
            var target = cursusController.Index(year, weeknumber);

            // Assert
            Assert.IsInstanceOfType(target, typeof(ViewResult));
        }

        [TestMethod]
        public void UploadCursusFileGetReturnsCorrectIActionResult()
        {
            // Arrange
            CursusController cursusController = new CursusController(_casService, _cursusFileParser);

            // Act
            var target = cursusController.UploadCursusFile();

            // Assert
            Assert.IsInstanceOfType(target, typeof(ViewResult));
        }

        [TestMethod]
        public void UploadCursusFilePostReturnsCorrectIActionResult()
        {
            // Arrange
            CursusController cursusController = new CursusController(_casService, _cursusFileParser);

            // Act
            var target = cursusController.UploadCursusFile(null);

            // Assert
            Assert.IsInstanceOfType(target, typeof(ViewResult));
        }
    }
}
