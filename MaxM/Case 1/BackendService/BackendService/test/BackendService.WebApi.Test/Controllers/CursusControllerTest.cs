using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackendService.WebApi.Test.Mocks;
using BackendService.Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using BackendService.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.WebApi.Test.Controllers
{
    [TestClass]
    public class CursusControllerTest
    {

        [TestMethod]
        public void CursusFindByCalledTimesTest()
        {
            // Arrange
            using (var repositoryMock = new CursusRepositoryMock())
            {
                var target = new CursusController(repositoryMock);

                // Act
                target.GetByWeekAndYear(42, 2016);
                var result = target.GetByWeekAndYear(42, 2016);

                // Assert
                Assert.AreEqual(2, repositoryMock.TimesCalled);
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public void CursusFindByFaultyAndTimesCalledTest()
        {
            // Arrange
            using (var repositoryMock = new FaultyCursusRepositoryMock())
            {
                var target = new CursusController(repositoryMock);

                // Act
                target.GetByWeekAndYear(42, 2016);
                var result = target.GetByWeekAndYear(42, 2016);

                // Assert
                Assert.AreEqual(2, repositoryMock.TimesCalled);
                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
        }

        [TestMethod]
        public void CursusFindByCorrectlySortedTest()
        {
            // Arrange
            using (var repositoryMock = new CursusRepositoryMock())
            {
                var target = new CursusController(repositoryMock);
                var expectedResult = new List<Cursus>
                {
                    new Cursus { Id = 1, Title = "C# Programmeren", AmountOfDays = 2, StartDate = new DateTime(2016, 5, 2) },
                    new Cursus { Id = 3, Title = "C# Hands-on", AmountOfDays = 5, StartDate = new DateTime(2016, 5, 4) },
                    new Cursus { Id = 2, Title = "Advanced C#", AmountOfDays = 3, StartDate = new DateTime(2016, 5, 3) },
                }.OrderBy(x => x.StartDate).ToList();

                // Act
                target.GetByWeekAndYear(42, 2016);
                var result = target.GetByWeekAndYear(42, 2016);

                // Assert
                Assert.AreEqual(2, repositoryMock.TimesCalled);
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                Assert.AreNotEqual(null, result);
                Assert.AreEqual(expectedResult.Count(), ((result as OkObjectResult).Value as IEnumerable<Cursus>).Count());
                Assert.AreEqual(expectedResult.First().Id, ((result as OkObjectResult).Value as IEnumerable<Cursus>).First().Id);
                Assert.AreEqual(expectedResult.Last().Id, ((result as OkObjectResult).Value as IEnumerable<Cursus>).Last().Id);
                Assert.AreEqual(2, repositoryMock.TimesCalled);
            }
        }

        [TestMethod]
        public void CursusPostTimesCalledTest()
        {
            // Arrange
            using (var repositoryMock = new CursusRepositoryMock())
            {
                var target = new CursusController(repositoryMock);

                // Act
                target.Post(new Cursus());
                target.Post(new Cursus());
                var result = target.Post(new Cursus());

                // Assert
                Assert.AreEqual(3, repositoryMock.TimesCalled);
                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        private bool CompareCursus(Cursus firstCursus, Cursus secondCursus)
        {
            if (firstCursus.Id != secondCursus.Id)
            {
                return false;
            }
            if (firstCursus.Title != secondCursus.Title)
            {
                return false;
            }
            if (firstCursus.StartDate != secondCursus.StartDate)
            {
                return false;
            }
            if (firstCursus.AmountOfDays != secondCursus.AmountOfDays)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CompareCursusList
        /// Because: http://stackoverflow.com/a/14047221
        /// </summary>
        /// <param name="firstList"></param>
        /// <param name="secondList"></param>
        /// <returns></returns>
        private bool CompareCursusList(List<Cursus> firstList, List<Cursus> secondList)
        {
            if (firstList == null || secondList == null)
            {
                throw new ArgumentNullException();
            }
            if (firstList.Count() != secondList.Count())
            {
                return false;
            }
            for (var i = 0; i < firstList.Count(); i++)
            {
                var result = CompareCursus(firstList[i], secondList[i]);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
    }
}