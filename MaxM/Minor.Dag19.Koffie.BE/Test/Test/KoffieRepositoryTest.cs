using Backend.Controllers;
using Backend.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Test.Mock;

namespace Test
{
    [TestClass]
    public class KoffieRepositoryTest
    {
        [TestMethod]
        public void GetTest()
        {
            // Arrange
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Get(1);
            target.Get(2);

            // Assert
            Assert.AreEqual(koffieRepository.GetById(2), koffieRepository.LastGetByIdKoffie);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            KoffieRepositoryMock koffieRepository = new KoffieRepositoryMock();
            var target = new KoffieController(koffieRepository);

            // Act
            target.Get();

            // Assert
            CollectionAssert.AreEqual(koffieRepository.GetAll().ToList(), koffieRepository.LastGetAllCollection.ToList());
        }
    }
}
