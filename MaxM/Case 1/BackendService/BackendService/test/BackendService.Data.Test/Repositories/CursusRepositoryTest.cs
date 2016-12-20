using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BackendService.DAL.DatabaseContexts;
using BackendService.DAL.DAL;
using BackendService.Entities.Entities;
using System;

namespace BackendService.Data.Test
{
    [TestClass]
    public class CursusRepositoryTest
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
            // Arrange
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                // Act
                repo.Insert(new Cursus()
                {
                    Id = 1,
                    CursusCode = "Naam"
                });
            }

            // Assert
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestAddMultiple()
        {
            // Arrange
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                // Act
                repo.Insert(new Cursus()
                {
                    Id = 1,
                    CursusCode = "Naam"
                });
                repo.Insert(new Cursus()
                {
                    Id = 3,
                    CursusCode = "Andere naam"
                });
            }

            // Assert
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void TestCount()
        {
            // Arrange
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                // Act
                repo.Insert(new Cursus()
                {
                    Id = 1,
                    CursusCode = "Naam"
                });
                repo.Insert(new Cursus()
                {
                    Id = 2,
                    CursusCode = "Andere naam"
                });
                repo.Insert(new Cursus()
                {
                    Id = 3,
                    CursusCode = "Nieuwere naam"
                });
                repo.Insert(new Cursus()
                {
                    Id = 4,
                    CursusCode = "Laatste naam"
                });
            }

            // Assert
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(4, repo.Count());
            }
        }

        [TestMethod]
        public void TestFindBy()
        {
            // Arrange
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                // Act
                repo.Insert(new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = new DateTime(2016, 5, 2) });
                repo.Insert(new Cursus { Id = 3, Title = "C# Hands-on", AmountOfDays = 5, StartDate = new DateTime(2016, 5, 4) });
                repo.Insert(new Cursus { Id = 2, Title = "Advanced C#", AmountOfDays = 3, StartDate = new DateTime(2016, 5, 3) });
            }

            // Assert
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(3, repo.FindBy(x => x.Title.Contains("#")).Count());
            }
        }

        [TestMethod]
        public void TestFindBy2()
        {
            // Arrange
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                // Act
                repo.Insert(new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = new DateTime(2016, 5, 2) });
                repo.Insert(new Cursus { Id = 3, Title = "C# Hands-on", AmountOfDays = 5, StartDate = new DateTime(2016, 5, 4) });
                repo.Insert(new Cursus { Id = 2, Title = "Advanced C#", AmountOfDays = 3, StartDate = new DateTime(2016, 5, 3) });
            }

            // Assert
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(2, repo.FindBy(x => x.Title.Contains("# ")).Count());
            }
        }
    }
}
