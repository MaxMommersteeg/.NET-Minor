using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag33.MoQDemo.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void CreateOrderTest()
        {
            // Arrange
            CreateOrderCommand coc = new CreateOrderCommand();

            Mock<IOrderRepository> mock = new Mock<IOrderRepository>(MockBehavior.Strict);
            mock.Setup(repo => repo.Insert(It.IsAny<Order>()));
            mock.Setup(repo => repo.FindOrderByID(It.IsAny<long>()))
                .Returns<Order>(null);

            Order order = new Order(mock.Object);

            // Act
            order.Create(coc);

            //Assert
            mock.Verify(repo => repo.Insert(It.IsAny<Order>()), Times.Once());
        }

        //[TestMethod]
        //public void NoDuplicateOrder()
        //{
        //    // Arrange
        //    CreateOrderCommand coc = new CreateOrderCommand() { Ordernumber = 7 };

        //    Mock<IOrderRepository> mock = new Mock<IOrderRepository>(MockBehavior.Strict);
        //    mock.Setup(repo => repo.Insert(It.Is<Order>(o => o.Ordernumber == 7)))
        //        .Throws<DuplicateOrderException>();

        //    Order order = new Order(mock.Object);

        //    // Act
        //    Action action = () => order.Create(coc);

        //    Assert.ThrowsException<DuplicateOrderException>(action);
        //}

        [TestMethod]
        public void NoDuplicateOrder()
        {
            // Arrange
            CreateOrderCommand coc = new CreateOrderCommand() { Ordernumber = 7 };

            Mock<IOrderRepository> mock = new Mock<IOrderRepository>(MockBehavior.Strict);
            mock.Setup(repo => repo.FindOrderByID(7))
                .Returns((long n) => new Order() { Ordernumber = n });

            Order order = new Order(mock.Object);

            // Act
            Action action = () => order.Create(coc);

            Assert.ThrowsException<DuplicateOrderException>(action);
        }
    }
}
