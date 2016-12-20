using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using Minor.Dag21.CAS.BackEnd.DAL.DAL;

namespace Minor.Dag21.CAS.BackEnd.Data.Test
{
    [TestClass]
    public class DALTest
    {
        private DbContextOptions _options;
        private static DbContextOptions<DatabaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestInitialize]
        public void Init()
        {
            _options = CreateNewContextOptions();
        }

        [TestMethod]
        public void TestAdd()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "Name"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                //Act
                repo.Insert(cursusInstantie);
            }


            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFind()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "Name"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 10),
                    Cursus = cursus
                };
                //Act
                repo.Insert(cursusInstantie);
                var res = repo.Find(1);
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Assert
                var result = repo.Find(1);
                Assert.AreEqual("test", result.Cursus.Cursuscode);
                Assert.AreEqual(5, result.Cursus.Duur);

                Assert.AreEqual("Name", result.Cursus.Titel);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                repo.Insert(cursusInstantie);
                repo.Delete(cursusInstantie);
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Assert
                Assert.AreEqual(0, repo.Count());
            }
        }
        [TestMethod]
        public void TestFindAll()
        {
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                var cursusInstantie2 = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 9),
                    Cursus = cursus
                };
                //Act
                repo.Insert(cursusInstantie);
                repo.Insert(cursusInstantie2);

            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Assert
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void TestAddSameCursus()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                repo.Insert(cursusInstantie);
                //Assert
                Assert.ThrowsException<DbUpdateException>(() => repo.Insert(cursusInstantie));

            }

        }

        [TestMethod]
        public void VoegMeerdereCursusInstantieToeMetAndereStartDatum()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                repo.Insert(cursusInstantie);
                //Assert
                Assert.ThrowsException<DbUpdateException>(() => repo.Insert(cursusInstantie));

            }

        }

        [TestMethod]
        public void VoegMeerdereCursusInstantiesVindSlechts1()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                repo.Insert(cursusInstantie);

                var cursusInstantie2 = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 3, 10),
                    Cursus = cursus
                };
                repo.Insert(cursusInstantie2);

                DateTime targetDateStart = new DateTime(2016, 10, 10);
                DateTime targetDateEind = new DateTime(2016, 10, 10);


                //Act
                var result = repo.FindBy(c => c.Startdatum >= targetDateStart && c.Startdatum <= targetDateEind);
                var resultTotaal = repo.FindAll();
                //Assert
                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(2, resultTotaal.Count());
            }

        }

        [TestMethod]
        public void VoegMeerdereCursusInstantiesVindSlechts1ContentCheck()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
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
                repo.Insert(cursusInstantie);

                var cursusInstantie2 = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 3, 10),
                    Cursus = cursus
                };
                repo.Insert(cursusInstantie2);

                DateTime targetDateStart = new DateTime(2016, 10, 10);
                DateTime targetDateEind = new DateTime(2016, 10, 17);


                //Act
                var result = repo.FindBy(c => c.Startdatum >= targetDateStart && c.Startdatum < targetDateEind);
                //Assert
                Assert.AreEqual(targetDateStart, result.First().Startdatum);


            }

        }

        [TestMethod]
        public void VoegMeerdereCursusInstantiesVindSlechts1ContentCheckNonSame()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                //Arrange
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 15),
                    Cursus = cursus
                };
                repo.Insert(cursusInstantie);

                var cursusInstantie2 = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 3, 10),
                    Cursus = cursus
                };
                repo.Insert(cursusInstantie2);

                DateTime targetDateStart = new DateTime(2016, 10, 10);
                DateTime targetDateEind = new DateTime(2016, 10, 17);


                //Act
                var result = repo.FindBy(c => c.Startdatum >= targetDateStart && c.Startdatum < targetDateEind);
                //Assert
                Assert.AreEqual(targetDateStart.AddDays(5), result.First().Startdatum);


            }

        }

        [TestMethod]
        public void CursistGetAll()
        {

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                //Arrange

                //Act
                var result = repo.FindAll();
                //Assert
                Assert.IsInstanceOfType(result,typeof(IEnumerable<Cursist>));
            }
        }

        [TestMethod]
        public void CursistInsertThenGetAll()
        {

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                //Arrange
                Cursist cursist = new Cursist();
                //Act
                repo.Insert(cursist);
                var result = repo.FindAll();
                //Assert
                Assert.IsInstanceOfType(result, typeof(IEnumerable<Cursist>));
                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public void CursistInsertDeleteThenGetAllCount0()
        {

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                //Arrange
                var cursus = new Cursus()
                {
                    Cursuscode = "test",
                    Duur = 5,
                    Titel = "C# testing"
                };
                var cursusInstantie = new CursusInstantie()
                {
                    Startdatum = new DateTime(2016, 10, 15),
                    Cursus = cursus
                };

                Cursist cursist = new Cursist() {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                    };
                //Act
                repo.Insert(cursist);
                repo.Delete(1);
                var result = repo.FindAll();
                //Assert
                Assert.IsInstanceOfType(result, typeof(IEnumerable<Cursist>));
                Assert.AreEqual(0, result.Count());
            }
        }

        [TestMethod]
        public void CursistInsert2ThenGetAllCount2()
        {

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                //Arrange
                Cursist cursist = new Cursist()
                {
                    Voornaam = "Kees",
                    Achternaam = "Koning",
                    CursusInstantieID = 1
                };
                Cursist cursist2 = new Cursist()
                {
                    Voornaam = "Marco",
                    Achternaam = "Pil",
                    CursusInstantieID = 2
                };
                //Act
                repo.Insert(cursist);
                repo.Insert(cursist2);

                var result = repo.FindAll();
                //Assert
                Assert.IsInstanceOfType(result, typeof(IEnumerable<Cursist>));
                Assert.AreEqual(2, result.Count());
            }
        }
    }
}
