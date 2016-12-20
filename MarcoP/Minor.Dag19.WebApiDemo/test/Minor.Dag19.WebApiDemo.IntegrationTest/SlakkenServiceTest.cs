using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.WebApiDemo.IntegrationTest
{
    [TestClass]
    public class SlakkenServiceTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("api/v1/slakken");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("[{\"id\":7,\"naam\":\"Slakkie\"},{\"id\":17,\"naam\":\"Lars\"},{\"id\":37,\"naam\":\"Gert\"}]",    responseString);
        }
   
    }
}
