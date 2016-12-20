using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag18.MonumentenSite.Test
{
    [TestClass]
    public class MonumententenSite_Automatic_Test
    {
        [TestMethod]
        public async Task GetTest()
        {
            // Arrange
            var _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory() + @"\..\..\src\Minor.Dag18.MonumentenSite"));
            var _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("/Monument/Index");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.IsTrue(responseString.Contains("Stad"));
        }

    }
}
