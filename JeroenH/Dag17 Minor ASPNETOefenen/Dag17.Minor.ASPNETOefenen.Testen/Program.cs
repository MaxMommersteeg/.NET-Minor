using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dag17.Minor.ASPNETOefenen.Testen
{
    [TestClass]
    public class MonumentenTesten
    {
        
        private List<Monument> _CreateDummyList()
        {
            return new List<Monument> {
                new Monument() { MonumentNaam = "Brandenburgertor" }
            };
        }

        [TestMethod]
        public void IndexViewResultCheckNotNull()
        {
            //Arrange
            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            //Act
            IActionResult result = monumentenController.Index();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewResultCheckIfView()
        {
            //Arrange
            var monumentenController = new MonumentenController(
                new MockMonumentAgent()
                );

            //Act
            IActionResult result = monumentenController.Index();

            //Assert
            Assert.IsInstanceOfType((result as ViewResult),typeof(ViewResult));
        }

        [TestMethod]
        public void IndexViewResultCheckModelTypeOfMonumenten()
        {
            //Arrange
            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());


            //Act
            IActionResult result = monumentenController.Index();
            var resultModel = (List<Monument>)(result as ViewResult).Model;

            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
        }

        [TestMethod]
        public void IndexViewResultCheckModelSizeOfGivenList()
        {
            //Arrange

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());

            //Act
            IActionResult result = monumentenController.Index();

            var resultModel = (List<Monument>) (result as ViewResult).Model;

            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            Assert.AreEqual(1, resultModel.Count);
        }

        [TestMethod]
        public void IndexViewResultCheckModelContentGivenDummyList()
        {
            //Arrange

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());

            //Act
            IActionResult result = monumentenController.Index();

            var resultModel = (List<Monument>)(result as ViewResult).Model;

            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            Assert.AreEqual("Brandenburgertor", resultModel[0].MonumentNaam);
        }

        [TestMethod]
        public void ToevoegenMonumentViewResultTypeCheck()
        {
            //Arrange

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());

            //Act
            IActionResult result = monumentenController.Toevoegen(new Monument());



            //Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void ToevoegenMonumentViewResultNullCheck()
        {
            //Arrange

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());

            //Act
            IActionResult result = monumentenController.Toevoegen(new Monument());



            //Assert
            Assert.IsNotNull((result as ViewResult));
        }

        [TestMethod]
        public void ToevoegenMonumentViewResultModelSizeCheck()
        {
            //Arrange

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(_CreateDummyList());

            //Act
            IActionResult result = monumentenController.Toevoegen(new Monument());

            var resultModel = (List<Monument>)(result as ViewResult).Model;


            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            Assert.AreEqual(2, resultModel.Count);
        }

        [TestMethod]
        public void ToevoegenMonumentViewResultModelContentCheck()
        {
            //Arrange
            var dummyList = _CreateDummyList();

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(dummyList);

            Monument pizzahut = new Monument() { MonumentNaam = "Pizzahut" };
            //Act

            IActionResult result = monumentenController.Toevoegen(pizzahut);

            var resultModel = (List<Monument>)(result as ViewResult).Model;

            
            dummyList.Add(pizzahut);

            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            CollectionAssert.AreEquivalent(dummyList, resultModel);
        }

        [TestMethod]
        public void VerwijderenMonumentViewResultTypeCheck()
        {
            //Arrange

            var dummyList = _CreateDummyList();

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(dummyList);

            Monument dummyMonument = new Monument();
            monumentenController.Toevoegen(dummyMonument);


            //Act
            IActionResult result = monumentenController.Verwijderen(dummyMonument);



            //Assert
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }

        [TestMethod]
        public void VerwijderenMonumentViewResultModelSizeCheck()
        {
            //Arrange

            var dummyList = _CreateDummyList();

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(dummyList);

            Monument dummyMonument = new Monument();
            monumentenController.Toevoegen(dummyMonument);

            //Act
            IActionResult result = monumentenController.Verwijderen(dummyMonument);

            var resultModel = (List<Monument>)(result as ViewResult).Model;


            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            Assert.AreEqual(1, resultModel.Count);
        }

        [TestMethod]
        public void VerwijderenMonumentViewResultModelContentCheck()
        {
            //Arrange
            var dummyList = _CreateDummyList();

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(dummyList);

            Monument pizzahut = new Monument() { MonumentNaam = "Pizzahut" };

            monumentenController.Toevoegen(pizzahut);
            //Act

            IActionResult result = monumentenController.Verwijderen(pizzahut);

            var resultModel = (List<Monument>)(result as ViewResult).Model;

            //Assert
            Assert.IsNotNull(resultModel);
            Assert.IsInstanceOfType(resultModel, typeof(List<Monument>));
            CollectionAssert.DoesNotContain(resultModel, pizzahut);
        }

        [TestMethod]
        public void ToevoegenPaginaOphalenViewResultTypeCheck()
        {
            //Arrange
            var dummyList = _CreateDummyList();

            var monumentenController = new MonumentenMockController(
                new MockMonumentAgent()
                );

            monumentenController.setList(dummyList);


            //Act

            IActionResult result = monumentenController.Toevoegen();


            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType((result as ViewResult), typeof(ViewResult));
        }
    }
}
