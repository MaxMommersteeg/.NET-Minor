using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.Repositories
{
    [TestClass]
    public class ApkAanvraagLogRepositoryTest
    {
        private DbContextOptions _options;

        [TestInitialize]
        public void Init() 
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            _options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            //_options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();
        }

        [TestMethod]
        public void ApkAanvraagLogRepositoryAddTest() 
        {
            // Arrange - Act
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                repo.Insert(new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString()
                });
            }

            // Assert
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void ApkAanvraagLogRepositoryFindTest() 
        {
            // Arrange
            string requestMessage = "RequestMessage";
            string responseMessage = "ResponseMessage";

            // Act
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                repo.Insert(new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestMessage = requestMessage,
                    ResponseMessage = responseMessage
                });
            }

            // Assert
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual(requestMessage, result.RequestMessage);
                Assert.AreEqual(responseMessage, result.ResponseMessage);
            }
        }
        [TestMethod]
        public void ApkAanvraagLogRepositoryDeleteTest() 
        {
            // Arrange
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                var apkAanvraagLog = new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestMessage = "RequestMessage",
                    ResponseMessage = "ResponseMessage"
                };
                // Act
                repo.Insert(apkAanvraagLog);
                repo.Delete(1);
            }

            // Assert
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                Assert.AreEqual(0, repo.Count());
            }
        }

        [TestMethod]
        public void ApkAanvraagLogRepositoryFindAllTest() 
        {
            // Arrange - Act
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                var apkAanvraagLog1 = new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestMessage = "RequestMessage 1",
                    ResponseMessage = "ResponseMessage 1"
                };
                repo.Insert(apkAanvraagLog1);
                var apkAanvraagLog2 = new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestMessage = "RequestMessage 2",
                    ResponseMessage = "ResponseMessage 2"
                };
                repo.Insert(apkAanvraagLog2);
            }

            // Assert
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void ApkAanvraagLogRepositoryUpdateTest() 
        {
            // Arrange
            string updatedRequestMessage = "Updated requestMessage";
            string updatedResponseMessage = "Updated responseMessage";
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                repo.Insert(new ApkAanvraagLog()
                {
                    CorrelationId = Guid.NewGuid().ToString(),
                    RequestMessage = "RequestMessage",
                    ResponseMessage = "ResponseMessage"
                });
            }

            // Act
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                repo.Update(new ApkAanvraagLog() 
                {
                    Id = 1,
                    RequestMessage = updatedRequestMessage,
                    ResponseMessage = updatedResponseMessage
                });
            }

            // Assert
            using (var repo = new ApkAanvraagLogRepository(new RdwContext(_options))) 
            {
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual(updatedRequestMessage, repo.Find(1).RequestMessage);
                Assert.AreEqual(updatedResponseMessage, repo.Find(1).ResponseMessage);
            }
        }
    }
}
