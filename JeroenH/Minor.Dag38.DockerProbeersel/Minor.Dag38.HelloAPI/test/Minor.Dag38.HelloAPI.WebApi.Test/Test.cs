using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag38.HelloAPI.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag38.HelloAPI.WebApi.Test
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void ValueGetTest()
        {
            using (var repo = new RepositoryMock())
            {
                var target = new ValuesController(repo);

                IEnumerable<Value> result = target.Get();

                Assert.AreEqual("Dom", result.First().Name);
                Assert.AreEqual(2, result.Count());
            }
        }

        [TestMethod]
        public void ValuesGetWithIdTest()
        {
            using (var repo = new RepositoryMock())
            {
                var target = new ValuesController(repo);

                var result = target.Get(2);

                Assert.AreEqual("Eifeltoren", result.Name);
                Assert.AreEqual("Frankfurt", result.Location);
                Assert.AreEqual(2, result.Id);
            }
        }

        [TestMethod]
        public void ValuesPostTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new ValuesController(repo);

                target.Post(new Value());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void ValuesPutTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new ValuesController(repo);

                target.Put(new Value());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void ValuesDeletTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new ValuesController(repo);

                target.Delete(2);

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }
    }
}