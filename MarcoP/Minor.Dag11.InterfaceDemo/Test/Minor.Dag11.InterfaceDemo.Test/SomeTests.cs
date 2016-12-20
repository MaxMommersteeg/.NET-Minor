using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag11.InterfaceDemo.Test
{
    [TestClass]
    public class SomeTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            IPainter painter = new Painter();

            painter.Draw();
        }

        [TestMethod]
        public void t2()
        {
            CowboyPainter cp = new CowboyPainter();

            IPainter cPAINTER = cp;
            cPAINTER.Draw();

            ICowboy COWBOYp = cp;
            COWBOYp.Draw();

            (cp as IPainter).Draw();
            (cp as ICowboy).Draw();
        }
    }
}
