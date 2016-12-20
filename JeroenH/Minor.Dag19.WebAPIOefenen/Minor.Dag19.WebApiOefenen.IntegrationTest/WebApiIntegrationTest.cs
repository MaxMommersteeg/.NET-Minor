using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.WebAPITraining;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag19.WebApiOefenen.IntegrationTest
{
    [TestClass]
    public class IntegrationTesting
    {
        [TestMethod]
        public async Task GetIntegrationTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();
            // Act
            var response = await _client.GetAsync("http://localhost:28311/api/v1/Monument");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual("[{\"id\":10,\"monumentNaam\":\"Dom\"},{\"id\":11,\"monumentNaam\":\"Martinitoren\"},{\"id\":12,\"monumentNaam\":\"Don Jon\"}]", responseString);


        }

        [TestMethod]
        public async Task PostDeleteIntegrationTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var _client = _server.CreateClient();
            // Act
            var response = await _client.DeleteAsync("http://localhost:28311/api/v1/Monument/10");
            response.EnsureSuccessStatusCode();
            Monument dom = new Monument() { Id=10, MonumentNaam="Dom"};
            var stringPayload = JsonConvert.SerializeObject(dom);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response2 = await _client.PostAsync("http://localhost:28311/api/v1/Monument",httpContent);
            response2.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("http://localhost:28311/api/v1/Monument");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual("[{\"id\":11,\"monumentNaam\":\"Martinitoren\"},{\"id\":12,\"monumentNaam\":\"Don Jon\"},{\"id\":10,\"monumentNaam\":\"Dom\"}]", responseString);


        }
    }
}
