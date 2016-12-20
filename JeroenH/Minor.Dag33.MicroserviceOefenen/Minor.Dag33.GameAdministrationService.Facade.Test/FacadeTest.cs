using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag33.GameAdministrationService.FacadeAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag33.GameAdministrationService.Facade.Test
{
    [TestClass]
    public class FacadeTest
    {
        [TestMethod]
        public void CreateAnyGameroom()
        {
            //Arrange
            var mock = new Mock<IRepository>(MockBehavior.Strict);

            mock.Setup(room => room.Insert(It.IsAny<Gameroom>()));

            GameroomController target = new GameroomController(mock.Object);

            CreateGameroomCommand command = new CreateGameroomCommand();
            
            //Act
            target.Create(command);

            //Assert
            mock.Verify(room => room.Insert(It.IsAny<Gameroom>()));
        }

        [TestMethod]
        public void CreateGameroomContentVerification()
        {
            //Arrange
            var mock = new Mock<IRepository>(MockBehavior.Strict);

            string roomname = "bla";
            string gamename = "tic-tac-toe";
            TTTColour colour = TTTColour.Circle;

            CreateGameroomCommand command = new CreateGameroomCommand() { Roomname = roomname, Gamename = gamename, Colour = colour };

            mock.Setup(repo => repo.Insert(It.IsAny<Gameroom>()));

            GameroomController target = new GameroomController(mock.Object);          

            //Act
            target.Create(command);

            //Assert
            mock.Verify(repo => repo.Insert(It.Is<Gameroom>(
                input => input.Roomname == roomname
                && input.Gamename == gamename
                && input.Colour == colour)
                ),Times.Once()
            );
        }
    }
}
