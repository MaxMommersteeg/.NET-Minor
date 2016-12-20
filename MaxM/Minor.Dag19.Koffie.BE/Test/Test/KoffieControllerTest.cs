using Backend.Controllers;
using Backend.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class KoffieControllerTest
    {
        [TestMethod]
        public void GetCallGetByIdTest()
        {
            // Arrange
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Get(1);

            // Assert
            Assert.AreEqual(1, koffieRepository.GetByIdCalled);
        }

        [TestMethod]
        public void GetCallGetById2TimesTest()
        {
            // Arrange
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Get(1);
            target.Get(2);

            // Assert
            Assert.AreEqual(2, koffieRepository.GetByIdCalled);
        }

        [TestMethod]
        public void GetCallGetAllTest()
        {
            // Arrange
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Get();
            target.Get();
            target.Get();

            // Assert
            Assert.AreEqual(3, koffieRepository.GetAllCalled);
        }

        [TestMethod]
        public void PostCallTest()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 35, Naam = "Nieuwe Koffie" };
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Post(newKoffie);

            // Assert
            Assert.AreEqual(1, koffieRepository.InsertCalled);
            Assert.AreEqual(newKoffie, koffieRepository.LastInsertKoffie);
        }

        [TestMethod]
        public void PostCall2TimesTest()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 35, Naam = "Nieuwe Koffie" };
            var nieuwereKoffie = new Koffie { Id = 38, Naam = "Nieuwere Koffie" };
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Post(newKoffie);
            target.Post(nieuwereKoffie);

            // Assert
            Assert.AreEqual(2, koffieRepository.InsertCalled);
            Assert.AreEqual(nieuwereKoffie, koffieRepository.LastInsertKoffie);
        }

        [TestMethod]
        public void PutCallTest()
        {
            // Arrange
            var newKoffie = new Koffie { Id = 1, Naam = "Nieuwe Koffie" };
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Put(newKoffie.Id, newKoffie);
            target.Put(newKoffie.Id, newKoffie);

            // Assert
            Assert.AreEqual(2, koffieRepository.UpdateCalled);
            Assert.AreEqual(newKoffie, koffieRepository.LastUpdateKoffie);
        }

        [TestMethod]
        public void DeleteCallTest()
        {
            // Arrange
            int koffieId = 1;
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Delete(koffieId);
            target.Delete(koffieId);

            // Assert
            Assert.AreEqual(2, koffieRepository.DeleteCalled);
            Assert.AreEqual(1, koffieRepository.LastDeletedId);

        }
    }
}
