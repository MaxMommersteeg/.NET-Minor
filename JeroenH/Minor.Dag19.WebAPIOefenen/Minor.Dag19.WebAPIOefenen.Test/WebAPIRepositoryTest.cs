using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebAPIOefenen.Test
{
    [TestClass]
    public class WebAPIRepositoryTest
    {
        [TestMethod]
        public void RepositoryFindAllTestNull()
        {
            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            //Act
            var monumentenList = monumentenRepository.FindAll();

            //Assert
            Assert.IsNotNull(monumentenList);
        }

        [TestMethod]
        public void RepositoryFindAllTestType()
        {


            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            //Act
            var monumentenList = monumentenRepository.FindAll();

            //Assert
            Assert.IsInstanceOfType(monumentenList as List<Monument>, typeof(List<Monument>));
        }

        [TestMethod]
        public void RepositoryInsertMonumentAndFindingIt()
        {
            
            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };

            List<Monument> expectedList = (List<Monument>)monumentenRepository.FindAll();
            expectedList.Add(dummyMonument);


            //Act
            monumentenRepository.Add(dummyMonument);

            var monumentenList = monumentenRepository.FindAll();

            //Assert
            Assert.IsInstanceOfType(monumentenList as List<Monument>, typeof(List<Monument>));
            CollectionAssert.AreEquivalent(expectedList, monumentenList as List<Monument>);
        }

        [TestMethod]
        public void RepositoryRemoveMonumentAndNotFindingIt()
        {

            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };

            List<Monument> expectedList = new List<Monument> { dummyMonument };

            monumentenRepository.Add(dummyMonument);


            //Act
            monumentenRepository.Remove((int)dummyMonument.Id);

            var monumentenList = monumentenRepository.FindAll();

            //Assert
            Assert.IsInstanceOfType(monumentenList as List<Monument>, typeof(List<Monument>));
            CollectionAssert.DoesNotContain(monumentenList as List<Monument>, dummyMonument);
        }

        [TestMethod]
        public void RepositoryFindById()
        {

            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };

            monumentenRepository.Add(dummyMonument);


            //Act

            var monument = monumentenRepository.Find(dummyMonument.Id);

            //Assert
            Assert.AreEqual(monument, dummyMonument);
        }

        [TestMethod]
        public void RepositoryUpdateById()
        {

            //Arrange
            IRepository<Monument, long> monumentenRepository = new MonumentenRepository();

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };

            monumentenRepository.Add(dummyMonument);


            //Act

            dummyMonument.MonumentNaam = "Eifeltoren";

            monumentenRepository.Update(dummyMonument);


            var monument = monumentenRepository.Find(dummyMonument.Id);

            //Assert
            Assert.IsNotNull(monument);
            Assert.AreEqual(monument, dummyMonument);
        }
    }
}
