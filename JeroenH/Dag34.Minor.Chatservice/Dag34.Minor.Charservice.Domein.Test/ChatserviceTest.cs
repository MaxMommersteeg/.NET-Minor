using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dag34.Minor.Charservice.Domein.Test
{
    [TestClass]
    public class ChatserviceTest
    {
        [TestMethod]
        public void PropertiesTest()
        {
            //Arrange
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {                
                //Act
                var chatservice = new Chatservice.Chatservice(connection, channel);

                //Assert
                Assert.AreEqual(connection , chatservice._connection);
                Assert.AreEqual(channel, chatservice._channel);

            }
        }

        [TestMethod]
        public void SignUpSendingExchangeTest()
        {
            //Arrange
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var chatservice = new Chatservice.Chatservice(connection, channel);
                //Act
                chatservice.Sending();

                //Assert

                Assert.AreEqual(1,channel.QueueDelete(chatservice._queueName));


            }
        }
    }
}
