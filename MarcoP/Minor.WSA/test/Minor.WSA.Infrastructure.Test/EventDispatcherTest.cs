using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.WSA.Infrastructure.Test
{
    [TestClass]
    public class EventDispatcherTest
    {
        [TestMethod]
        public void BuildModelTest()
        {
            // Act
            using (var result = new MyTestDispatcher())
            {
                // Assert
                Assert.AreEqual(2, result.DispatcherModel.Count());
            }
        } 
    }
}
