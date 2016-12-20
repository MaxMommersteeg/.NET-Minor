using Backend;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTest
{

    [TestClass]
    public class IntegrationTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Initialize()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = testServer.CreateClient();
        }

        [TestMethod]
        public async Task GetAllTest()
        {
            
        }
    }
}
