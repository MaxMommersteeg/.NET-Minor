using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag09.DelegateDemo.NuEcht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag09.DelegateDemo.Test
{
    [TestClass]
    public class DelegateTest
    {
        [TestMethod]
        public void BijSwitchMeWordtDeMethodeAangeroepenDieWeHebbenToegevoegd()
        {
            // Arrange
            var target = new Switch();
            var listenerMock = new ListenerMock();
            target.Switched += listenerMock.SwitchHandled;

            // Act
            target.SwitchMe();

            // Assert
            Assert.IsTrue(listenerMock.SwitchHandledHasBeenCalled);
        }

        [TestMethod]
        public void BijRemoveWordtDeMethodeNietMeerAangeroepen()
        {
            // Arrange
            var target = new Switch();
            var listenerMock = new ListenerMock();
            target.Switched += listenerMock.SwitchHandled;

            // Act
            target.Switched -= listenerMock.SwitchHandled;
            target.SwitchMe();

            // Assert
            Assert.IsFalse(listenerMock.SwitchHandledHasBeenCalled);
        }

        [TestMethod]
        public void BijSwitchMeFliptDeToestand()
        {
            // Arrange
            var target = new Switch();
            var listenerMock = new ListenerMock();
            target.Switched += listenerMock.SwitchHandled;

            // Act
            target.SwitchMe();

            // Assert
            Assert.IsTrue(listenerMock.SwitchedEventArgs.State);
        }

        [TestMethod]
        public void BijTweemaalSwitchMeFliptDeToestandNiet()
        {
            // Arrange
            var target = new Switch();
            var listenerMock = new ListenerMock();
            target.Switched += listenerMock.SwitchHandled;

            // Act
            target.SwitchMe();
            target.SwitchMe();

            // Assert
            Assert.IsFalse(listenerMock.SwitchedEventArgs.State);
        }
    }
}
