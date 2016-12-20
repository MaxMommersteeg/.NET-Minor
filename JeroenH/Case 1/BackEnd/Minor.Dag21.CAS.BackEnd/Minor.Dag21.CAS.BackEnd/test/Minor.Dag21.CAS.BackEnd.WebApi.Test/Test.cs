using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using Minor.Dag21.CAS.BackEnd.WebApi.Controllers;
using Minor.Dag21.CAS.BackEnd.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Minor.Dag21.CAS.BackEnd.WebApi.Errors;


namespace Minor.Dag21.CAS.BackEnd.WebApi.Test
{
    [TestClass]
    public class CursusControllerTest
    {
        [TestMethod]
        public void CursusSetTest()
        {
            //Assert
            using (var repo = new CursusRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesFindAllCalled);

                var target = new CursusController(repo);

                //Act
               target.Get();

                //Assert
                Assert.AreEqual(1, repo.TimesFindAllCalled);


            }
        }

        [TestMethod]
        public void CursusGetWithIdTest()
        {
            //Assert
            using (var repo = new CursusRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesFindCalled);

                var target = new CursusController(repo);

                //Act
                var result = target.Get(2);

                //Assert
                Assert.AreEqual(1, repo.TimesFindCalled);
                Assert.AreEqual(2, repo.FindByIdLastCallContent);


            }

        }

        [TestMethod]
        public void CursusPostTest()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange
                Assert.AreEqual(0, repo.TimesInsertCalled);

                var target = new CursusController(repo);

                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                //Act
                target.Post(cursusInstantie);
                //Assert
                Assert.AreEqual(1, repo.TimesInsertCalled);
                Assert.AreEqual(cursusInstantie, repo.InsertLastCallContent);

            }
        }

        [TestMethod]
        public void CursusPutTest()
        {
            using (var repo = new CursusRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesUpdateCalled);

                var target = new CursusController(repo);

                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                target.Put(cursusInstantie);

                Assert.AreEqual(1, repo.TimesUpdateCalled);
                Assert.AreEqual(cursusInstantie, repo.UpdateLastCallContent);

            }
        }

        [TestMethod]
        public void CursusDeleteTest()
        {
            using (var repo = new CursusRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesDeleteCalled);

                var target = new CursusController(repo);

                target.Delete(2);

                Assert.AreEqual(1, repo.TimesDeleteCalled);
                Assert.AreEqual(2, repo.DeleteLastCallContent);

            }
        }

        [TestMethod]
        public void VindCursusLijstPerWeek()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange
                Assert.AreEqual(0, repo.TimesFindByCalled);

                var target = new CursusController(repo);
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };
                
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                target.Post(cursusInstantie);

                var cursusInstantie2 = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 3, 10),
                    Cursus = cursus
                };
                target.Post(cursusInstantie2);

                //Act
                target.GetByWeek(new DateTime(2016, 3, 10).ToString());

                //Assert
                Assert.AreEqual(1, repo.TimesFindByCalled);

            }
        }

        [TestMethod]
        public void VindCursusLijstPerWeekFaalend()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo); 

                //Act
                var result = target.GetByWeek("Faal maar");

                //Assert
                Assert.AreEqual(0, repo.TimesFindByCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
        }

        [TestMethod]
        public void VindCursusLijstPerWeekFaalendErrorMessage()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);

                //Act
                var result = target.GetByWeek("Faal maar");

                //Assert
                Assert.AreEqual(0, repo.TimesFindByCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
                var testResult = (result as BadRequestObjectResult).Value;
                Assert.AreEqual("datum is niet in juiste format", (testResult as Foutmelding).ErrorMessage);
                Assert.AreEqual(ErrorTypes.IncorrectInputFormat, (testResult as Foutmelding).ErrorType);

            }
        }

        [TestMethod]
        public void InsertCursusFaalendDuplicate()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };

                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                target.Post(cursusInstantie);


                //Act
                var result = target.Post(cursusInstantie);

                //Assert
                Assert.AreEqual(2, repo.TimesInsertCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
        }

        [TestMethod]
        public void InsertCursusFaalendDuplicateErrorMessage()
        {
            using (var repo = new CursusRepositoryMock())
            {
                var target = new CursusController(repo);
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };

                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                target.Post(cursusInstantie);


                //Act
                var result = target.Post(cursusInstantie);

                //Assert
                Assert.AreEqual(2, repo.TimesInsertCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
                var testResult = (result as BadRequestObjectResult).Value;
                Assert.AreEqual("This key already exist", (testResult as Foutmelding).ErrorMessage);
            }
        }

        [TestMethod]
        public void VindAlleCursussenFaalend()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);

                //Act
                var result = target.Get();

                //Assert
                Assert.AreEqual(1, repo.TimesFindAllCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
        }

        [TestMethod]
        public void VindAlleCursussenFaalendFoutmeldingTypeCheck()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);

                //Act
                var result = target.Get();

                //Assert
                Assert.AreEqual(1, repo.TimesFindAllCalled);
                Assert.IsInstanceOfType((result as BadRequestObjectResult).Value, typeof(Foutmelding));
            }
        }

        [TestMethod]
        public void VindAlleCursussenFaalendErrorMessage()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);

                //Act
                var result = target.Get();

                //Assert
                var testResult = (result as BadRequestObjectResult).Value;
                Assert.AreEqual(1, repo.TimesFindAllCalled);
                Assert.AreEqual("Oops, something went wrong", (testResult as Foutmelding).ErrorMessage);
            }
        }

        [TestMethod]
        public void DeleteNietBestaandeCursusFaalend()
        {
            using (var repo = new CursusRepositoryMock())
            {
                //Arrange

                var target = new CursusController(repo);

                //Act
                var result = target.Delete(1);

                //Assert
                Assert.AreEqual(1, repo.TimesDeleteCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
        }

        [TestMethod]
        public void InsertNewCursist()
        {
            using (var repo = new CursistRepositoryMock())
            {
                //Arrange
                var target = new CursistController(repo);

                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };

                //Act
                target.Post(cursist);

                //Assert
                Assert.AreEqual(1, repo.TimesInsertCalled);
                Assert.AreEqual(cursist, repo.InsertLastCallContent);
            }
        }

        [TestMethod]
        public void GetAllCursistenNaInsert()
        {
            using (var repo = new CursistRepositoryMock())
            {
                //Arrange
                var target = new CursistController(repo);

                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };
                target.Post(cursist);


                //Act
                target.Get();

                //Assert
                Assert.AreEqual(1, repo.TimesFindAllCalled);
            }
        }

        [TestMethod]
        public void GetSpecifiekeCursistNaInsert()
        {
            using (var repo = new CursistRepositoryMock())
            {
                //Arrange
                var target = new CursistController(repo);


                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };
                target.Post(cursist);


                //Act
                target.Get(1);

                //Assert
                Assert.AreEqual(1, repo.TimesFindCalled);
                Assert.AreEqual(1, repo.FindByIdLastCallContent);

            }
        }

        [TestMethod]
        public void UpdateCursistNaInsert()
        {
            using (var repo = new CursistRepositoryMock())
            {
                //Arrange
                var target = new CursistController(repo);

                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };
                target.Post(cursist);

                cursist.Achternaam = "Pil";
                //Act
                target.Put(cursist);

                //Assert
                Assert.AreEqual(1, repo.TimesUpdateCalled);
                Assert.AreEqual(cursist, repo.UpdateLastCallContent);

            }
        }

        [TestMethod]
        public void GetInschrijvingenCursus()
        {
            using (var repo = new CursistRepositoryMock())
            {
                //Arrange
                var target = new CursistController(repo);

                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };
                target.Post(cursist);
                //Act
                target.GetInschrijvingen(1);

                //Assert
                Assert.AreEqual(1, repo.TimesFindByCalled);

            }
        }
    }
}