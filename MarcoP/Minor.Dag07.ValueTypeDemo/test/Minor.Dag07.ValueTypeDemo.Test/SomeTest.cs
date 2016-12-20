using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag07.ValueTypeDemo.Test
{
    [TestClass]
    public class SomeTest
    {
        [TestMethod]
        public void PersoonAanmaken()
        {
            var target = new Persoon("Marco", Geslacht.Man);

            Assert.AreEqual(Geslacht.Man, target.Geslacht);
        }

        [TestMethod]
        public void GeslachtsTest()
        {
            var target = new Persoon("Marco", Geslacht.Man);

            Assert.AreEqual("Man", target.Geslacht.ToString());
        }

        [TestMethod]
        public void GeslachtsTest2()
        {
            var target = new Persoon("Marco", (Geslacht)3);

            Geslacht manwijf = Geslacht.Vrouw | Geslacht.Man;

            Assert.AreEqual(manwijf, target.Geslacht);
        }


        [TestMethod]
        public void GeslachtsTest3()
        {
            var target = new Persoon("Marco", (Geslacht)3);


            Assert.AreEqual(Geslacht.Man, target.Geslacht & Geslacht.Man);
            Assert.AreEqual(Geslacht.Vrouw, target.Geslacht & Geslacht.Vrouw);
            Assert.AreNotEqual(Geslacht.Kind, target.Geslacht & Geslacht.Kind);
        }

    }
}
