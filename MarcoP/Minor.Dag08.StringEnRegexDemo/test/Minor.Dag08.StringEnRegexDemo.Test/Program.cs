using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag08.StringEnRegexDemo.Test
{
    [TestClass]
    public class Program
    {
        public void MyTestMethod()
        {
            string s = @"C:\tFS\marcop";
            int a = 3;
            string t = $"De waarde van a = {a} en de lengte van s = {s.Length+3}";
            t = t.Replace("a", "o");
        }
    }
}
