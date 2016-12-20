using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Test.Statussen 
{
    [TestClass]
    public class OpdrachtStatussenTest
    {
        [TestMethod]
        public void OpdrachtStatussenMethodsReturnExpected() 
        {
            // Arrange - Act
            var aangemeld = OpdrachtStatussen.Aangemeld();
            var klaarGemeld = OpdrachtStatussen.Klaargemeld();
            var afgemeld = OpdrachtStatussen.Afgemeld();
            var afgehandeld = OpdrachtStatussen.Afgehandeld();

            // Assert
            Assert.AreEqual(10, aangemeld.StatusId);
            Assert.AreEqual("Aangemeld", aangemeld.Beschrijving);

            Assert.AreEqual(20, klaarGemeld.StatusId);
            Assert.AreEqual("Klaar gemeld", klaarGemeld.Beschrijving);

            Assert.AreEqual(30, afgemeld.StatusId);
            Assert.AreEqual("Afgemeld", afgemeld.Beschrijving);

            Assert.AreEqual(100, afgehandeld.StatusId);
            Assert.AreEqual("Afgehandeld", afgehandeld.Beschrijving);
        }
    }
}
