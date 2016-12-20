using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.WebApiDemo.Controllers;
using Minor.Dag19.WebApiDemo.DAL;
using Minor.Dag19.WebApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebApiDemo.Test
{
    [TestClass]
    public class SlakkenControllerTest
    {
        [TestMethod]
        public void SlakkenGet()
        {
            IRepository<Slak,long> repositoryMock = new RepositoryMock();
            var target = new SlakkenController(repositoryMock);

            IEnumerable<Slak> result = target.Get();

            Assert.AreEqual("Wegslak", result.First().Naam);
        }

        [TestMethod]
        public void SlakkenPost()
        {
            RepositoryMock repositoryMock = new RepositoryMock();
            var target = new SlakkenController(repositoryMock);
            var slak = new Slak { ID = 3, Naam = "zwarte wegslak" };

            target.Post(slak);

            Assert.IsTrue(repositoryMock.InsertHasBeenCalled);
            Assert.AreEqual(3, repositoryMock.InsertParameter.ID);
            Assert.AreEqual("zwarte wegslak", repositoryMock.InsertParameter.Naam);
        }
    }
}
