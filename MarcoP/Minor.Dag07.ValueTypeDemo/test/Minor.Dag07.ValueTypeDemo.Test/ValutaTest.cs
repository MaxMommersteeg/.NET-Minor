using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag07.ValueTypeDemo.Test
{
    [TestClass]
    public class ValutaTest
    {
        [TestMethod]
        public void Maak_EUR3_25()
        {
            Valuta geld = new Valuta(3.25M, Muntsoort.Euro);

            string tekst = geld.ToString();

            Assert.AreEqual("EUR 3,25", tekst);

        }
    }
}
