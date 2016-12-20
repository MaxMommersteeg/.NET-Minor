using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebAPIOefenen.Test
{
    [TestClass]
    public class WebApiFacadeTest
    {
        [TestMethod]
        public void FacadeGetAllMonumentsCallCount()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            //Act
            IEnumerable<Monument> result = monumentController.Get();

            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesFindAllCalled);
        }

        [TestMethod]
        public void FacadeInsertAMonumentCallCount()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };


            //Act
            monumentController.Post(dummyMonument);

            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
        }

        [TestMethod]
        public void FacadeInsertAMonumentAndGetContent()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };


            //Act
            monumentController.Post(dummyMonument);

            List<Monument> result = (List<Monument>)monumentController.Get();

            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
            CollectionAssert.Contains(result, dummyMonument);
        }

        [TestMethod]
        public void FacadeInsertAMonumentAndRemoveCallCount()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };


            //Act
            monumentController.Post(dummyMonument);

            monumentController.Delete((int)dummyMonument.Id);

            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
            Assert.AreEqual(1, mockRepository.NumberOfTimesRemoveCalled);
        }

        [TestMethod]
        public void FacadeInsertAMonumentAndRemoveContentCheck()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };


            //Act
            monumentController.Post(dummyMonument);

            monumentController.Delete((int)dummyMonument.Id);

            List<Monument> result = (List<Monument>)monumentController.Get();


            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
            Assert.AreEqual(1, mockRepository.NumberOfTimesRemoveCalled);
            CollectionAssert.DoesNotContain(result, dummyMonument);
        }

        [TestMethod]
        public void FacadeGetByIdCallCount()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };
            
            //Act
            monumentController.Post(dummyMonument);            

            Monument result = monumentController.Get(1);
            
            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
            Assert.AreEqual(1, mockRepository.NumberOfTimesFindCalled);
            Assert.AreEqual(dummyMonument, result);
        }

        [TestMethod]
        public void FacadeUpdateCallCount()
        {
            //Arrange
            MockRepository mockRepository = new MockRepository();
            MonumentController monumentController = new MonumentController(mockRepository);

            Monument dummyMonument = new Monument() { Id = 1, MonumentNaam = "Manneke pis" };

            //Act
            monumentController.Post(dummyMonument);

            dummyMonument.MonumentNaam = "Eifeltoren";

            monumentController.Put((int)dummyMonument.Id,dummyMonument);

            Monument result = monumentController.Get(1);

            //Assert
            Assert.AreEqual(1, mockRepository.NumberOfTimesAddCalled);
            Assert.AreEqual(1, mockRepository.NumberOfTimesUpdateCalled);
            Assert.AreEqual(dummyMonument, result);
        }
    }
}
