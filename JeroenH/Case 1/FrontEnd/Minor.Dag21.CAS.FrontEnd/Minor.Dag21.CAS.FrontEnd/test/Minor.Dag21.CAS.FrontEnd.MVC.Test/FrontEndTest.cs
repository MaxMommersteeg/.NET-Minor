using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag21.CAS.FrontEnd.FrontEnd.Controllers;
using Minor.Dag21.CAS.FrontEnd.FrontEnd.ViewModels;
using Minor.Dag21.CAS.FrontEnd.MVC.Test.Mocks;
using Minor.Dag21.CASServiceClient.Agents.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag21.CAS.FrontEnd.MVC.Test
{
    [TestClass]
    public class FrontEndTest
    {
        [TestMethod]
        public void TestenFileUploadOntvangenBijController()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    //Assert
                    Assert.IsInstanceOfType(result, typeof(IActionResult));
                }
            }

        }

        [TestMethod]
        public void UploadenBestandTestAddAanroep()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);

                    //Assert
                    Assert.AreEqual(1, mockAgent.NumberOfTimesAddCalled);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestAddContentVolledigeCursusTitelCheck()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);

                    //Assert
                    Assert.AreEqual(1, mockAgent.NumberOfTimesAddCalled);
                    Assert.AreEqual("C# Programmeren", mockAgent.LijstCursusAddToevoeging[0].Cursus.Titel);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestAddContentVolledigeCursusCursusCodeCheck()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    //Assert
                    Assert.AreEqual(1, mockAgent.NumberOfTimesAddCalled);
                    Assert.AreEqual("CNETIN", mockAgent.LijstCursusAddToevoeging[0].Cursus.Cursuscode);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestAddContentVolledigeCursusCursusDuurCheck()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);

                    //Assert
                    Assert.AreEqual(1, mockAgent.NumberOfTimesAddCalled);
                    Assert.AreEqual(5, mockAgent.LijstCursusAddToevoeging[0].Cursus.Duur);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestAddContentVolledigeCursusStartDatumCheck()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    //Assert
                    Assert.AreEqual(1, mockAgent.NumberOfTimesAddCalled);
                    Assert.AreEqual(new DateTime(2014, 10, 11), mockAgent.LijstCursusAddToevoeging[0].Startdatum);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestAddMeerdereCursusResponseCount()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"TestFile\goedvoorbeeld.txt").ToList();

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
                    fileMock.Setup(m => m.Length).Returns(5);

                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);

                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;

                    Assert.AreEqual(4, viewModel.SuccesInsertCount);

                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestVerwijzingMessagePage()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"TestFile\goedvoorbeeld.txt").ToList();

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
                    fileMock.Setup(m => m.Length).Returns(5);

                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    Assert.IsInstanceOfType(result, typeof(IActionResult));
                    Assert.AreEqual("CursusCreateMessage", (result as ViewResult).ViewName);   
                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestVerwijzingMessagePageModelType()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"TestFile\goedvoorbeeld.txt").ToList();

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
                    fileMock.Setup(m => m.Length).Returns(5);

                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    Assert.IsInstanceOfType(result, typeof(IActionResult));
                    Assert.AreEqual("CursusCreateMessage", (result as ViewResult).ViewName);
                    Assert.IsNotNull((result as ViewResult).Model);
                    Assert.IsInstanceOfType((result as ViewResult).Model,typeof(CursusCreateMessageViewModel));

                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestVerwijzingMessagePageModelContentInsertCount4()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            var lines = File.ReadLines(@"TestFile\goedvoorbeeld.txt").ToList();

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
                    fileMock.Setup(m => m.Length).Returns(5);

                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(4, viewModel.SuccesInsertCount);
                    

                }
            }
        }

        [TestMethod]
        public void UploadenBestandTestVerwijzingMessagePageModelContentInsertCount1()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(1, viewModel.SuccesInsertCount);
                }
            }              
            
        }

        [TestMethod]
        public void UploadenBestandTestVerwijzingMessagePageModelContentDuplicateCount0()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(1, viewModel.TotalInsertCount);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandFaalendBestandTitel()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(1, viewModel.ErrorAtLine);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandFaalendBestandCursuscode()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(2, viewModel.ErrorAtLine);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandFaalendBestandCursusduur()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("5 dagen");
                    writer.WriteLine("Startdatum: 11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(3, viewModel.ErrorAtLine);
                }
            }
        }

        [TestMethod]
        public void UploadenBestandFaalendBestandCursusStartdatum()
        {
            //Arrange
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    var fileMock = new Mock<IFormFile>();
                    writer.WriteLine("Titel: C# Programmeren");
                    writer.WriteLine("Cursuscode: CNETIN");
                    writer.WriteLine("Duur: 5 dagen");
                    writer.WriteLine("11/10/2014 ");
                    writer.WriteLine("");

                    writer.Flush();
                    ms.Position = 0;
                    fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
                    fileMock.Setup(m => m.Length).Returns(5);


                    MockAgent mockAgent = new MockAgent();
                    var target = new CursusController(mockAgent);

                    //Act
                    var result = target.Create(fileMock.Object);
                    // Assert
                    CursusCreateMessageViewModel viewModel = (CursusCreateMessageViewModel)(result as ViewResult).Model;
                    Assert.IsNotNull(viewModel);
                    Assert.AreEqual(4, viewModel.ErrorAtLine);
                }
            }
        }

        [TestMethod]
        public void WeergevenHuidigeWeek()
        {
            //Arrange
            MockAgent mockAgent = new MockAgent();
            var target = new CursusController(mockAgent);

            //Act
            var result = target.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IActionResult));

        }

        [TestMethod]
        public void WeergevenHuidigeWeekModelCheck()
        {
            //Arrange
            MockAgent mockAgent = new MockAgent();
            var target = new CursusController(mockAgent);

            //Act
            var result = target.Index(41, 2016);

            //Assert
            var resultModel = (result as ViewResult).Model;
            Assert.IsInstanceOfType(result, typeof(IActionResult));
            Assert.IsInstanceOfType(resultModel, typeof(IEnumerable<CursusInstantie>));
        }

        [TestMethod]
        public void WeergevenHuidigeWeekModelCheckContent()
        {
            //Arrange
            MockAgent mockAgent = new MockAgent();
            var target = new CursusController(mockAgent);

            //Act
            var result = target.Index(41, 2016);

            //Assert
            var resultModel = (result as ViewResult).Model;
            Assert.IsInstanceOfType(resultModel, typeof(IEnumerable<CursusInstantie>));
            Assert.AreEqual(new DateTime(2016, 10, 10).Day, DateTime.Parse(mockAgent.LijstGetByWeekInput[0]).Day);
        }

        [TestMethod]
        public void WeergevenGekozenWeekModelCheckContent()
        {
            //Arrange
            MockAgent mockAgent = new MockAgent();
            var target = new CursusController(mockAgent);

            //Act
            var result = target.Index(40, 2016);

            //Assert
            var resultModel = (result as ViewResult).Model;
            Assert.IsInstanceOfType(resultModel, typeof(IEnumerable<CursusInstantie>));
            Assert.AreEqual(new DateTime(2016, 10, 03).Day, DateTime.Parse(mockAgent.LijstGetByWeekInput[0]).Day);
        }

        [TestMethod]
        public void FindAllCursist()
        {
            //Arrange
            MockAgent mockAgent = new MockAgent();
            var target = new CursistController(mockAgent);

            //Act
            target.Index();

            //Assert
            Assert.AreEqual(1, mockAgent.NumberOfTimesIndexCursistCalled);
        }

    }
}
