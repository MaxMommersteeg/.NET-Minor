using FrontEnd.Agents;
using FrontEnd.Agents.Models;
using FrontEnd.MVC.Test.Mocks;
using FrontEnd.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrontEnd.MVC.Test.Parsers
{
    [TestClass]
    public class CursusFileParserTest
    {
        private ICASService _casService;

        [TestInitialize]
        public void Initialize()
        {
            _casService = new CASServiceMock();
        }

        [TestMethod]
        public void CursusFileFout1Invalid()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Fout1.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.IsTrue(result.ErrorMessages.Count > 0);
                }
            }
        }

        [TestMethod]
        public void CursusFileFout2Invalid()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Fout2.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.IsTrue(result.ErrorMessages.Count > 0);
                }
            }
        }

        [TestMethod]
        public void CursusFileFout3Invalid()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Fout3.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.IsTrue(result.ErrorMessages.Count > 0);
                }
            }
        }

        [TestMethod]
        public void CursusFileFout4Invalid()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Fout4.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.IsTrue(result.ErrorMessages.Count > 0);
                }
            }
        }

        [TestMethod]
        public void CursusFileGoed1Valid()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Goed1.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.AreNotEqual(null, result);
                    Assert.IsInstanceOfType(result, typeof(ParsedCursusFileResultContainer));
                    Assert.IsInstanceOfType(result.ParsedCursussen, typeof(IEnumerable<Cursus>));
                    Assert.IsInstanceOfType(result.DuplicateCursussen, typeof(IEnumerable<Cursus>));
                    Assert.AreEqual(5, result.ParsedCursussen.Count());
                    Assert.AreEqual(0, result.DuplicateCursussen.Count());
                }
            }
        }

        [TestMethod]
        public void CursusFileDuplicates1()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Duplicates1.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.AreNotEqual(null, result);
                    Assert.IsInstanceOfType(result, typeof(ParsedCursusFileResultContainer));
                    Assert.IsInstanceOfType(result.ParsedCursussen, typeof(IEnumerable<Cursus>));
                    Assert.IsInstanceOfType(result.DuplicateCursussen, typeof(IEnumerable<Cursus>));
                    Assert.AreEqual(3, result.DuplicateCursussen.Count());
                    Assert.AreEqual(4, result.ParsedCursussen.Count());
                }
            }
        }

        [TestMethod]
        public void CursusFileDuplicates2()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Duplicates2.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.AreNotEqual(null, result);
                    Assert.IsInstanceOfType(result, typeof(ParsedCursusFileResultContainer));
                    Assert.IsInstanceOfType(result.ParsedCursussen, typeof(IEnumerable<Cursus>));
                    Assert.IsInstanceOfType(result.DuplicateCursussen, typeof(IEnumerable<Cursus>));
                    Assert.AreEqual(5, result.ParsedCursussen.Count());
                    Assert.AreEqual(2, result.DuplicateCursussen.Count());
                }
            }
        }

        [TestMethod]
        public void CursusFileDuplicates3()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"Parsers\TestFiles\Duplicates3.txt").ToList();
            var target = new CursusFileParser(_casService);

            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    for (var i = 0; i < lines.Count; i++)
                    {
                        streamWriter.WriteLine(lines[i]);
                    }
                    streamWriter.Flush();
                    memoryStream.Position = 0;

                    fileMock.Setup(m => m.OpenReadStream()).Returns(memoryStream);

                    var result = target.GetCursussenFromCursusFile(fileMock.Object);

                    // Assert
                    Assert.AreNotEqual(null, result);
                    Assert.IsInstanceOfType(result, typeof(ParsedCursusFileResultContainer));
                    Assert.IsInstanceOfType(result.ParsedCursussen, typeof(IEnumerable<Cursus>));
                    Assert.IsInstanceOfType(result.DuplicateCursussen, typeof(IEnumerable<Cursus>));
                    Assert.AreEqual(1, result.DuplicateCursussen.Count());
                    Assert.AreEqual(4, result.ParsedCursussen.Count());
                }
            }
        }

        [TestMethod]
        public void CursusFileParserInRange1()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2016, 1, 1) };
            var startDate = new DateTime(2015, 1, 1);
            var endDate = new DateTime(2017, 1, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CursusFileParserInRange2()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2014, 1, 1), AmountOfDays = 500 };
            var startDate = new DateTime(2015, 1, 1);
            var endDate = new DateTime(2017, 1, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CursusFileParserInRange3()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2016, 1, 1), AmountOfDays = 500 };
            var startDate = new DateTime(2016, 3, 1);
            var endDate = new DateTime(2016, 5, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CursusFileParserInRange4()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2016, 1, 1), AmountOfDays = 10 };
            var startDate = new DateTime(2016, 3, 1);
            var endDate = new DateTime(2016, 5, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CursusFileParserInRange5()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2016, 5, 1), AmountOfDays = 1 };
            var startDate = new DateTime(2016, 3, 1);
            var endDate = new DateTime(2016, 5, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CursusFileParserInRange6()
        {
            // Arrange
            var target = new CursusFileParser(_casService);
            var cursus = new Cursus { StartDate = new DateTime(2016, 5, 1), AmountOfDays = 1 };
            var startDate = new DateTime(2016, 3, 1);
            var endDate = new DateTime(2016, 5, 1);

            // Act
            var result = target.CursusInRange(startDate, endDate, cursus);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
