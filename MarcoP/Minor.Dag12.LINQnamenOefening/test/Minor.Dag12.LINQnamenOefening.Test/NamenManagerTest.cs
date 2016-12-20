using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag12.LINQnamenOefening.Test
{
    [TestClass]
    public class NamenManagerTest
    {
        private readonly List<string> namen = new List<string> {
            "Yael", "Rouke", "Wesley", "Simon", "Martin", "Jelle",
            "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
            "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
            "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery",
        };

        [TestMethod]
        public void VoorlettersVanNamenMetR_produceert_Voorletters()
        {
            var target = new NamenManager(new List<string> { "Marco", "Lars" });

            IEnumerable<char> result = target.VoorlettersVanNamenMetR();

            List<char> expected = new List<char> { 'M', 'L' };
            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void VoorlettersVanNamenMetR_selecteertAlleenNamenMetr()
        {
            var target = new NamenManager(new List<string> { "Jan", "Marco", "Bouke" });

            IEnumerable<char> result = target.VoorlettersVanNamenMetR();

            List<char> expected = new List<char> { 'M' };
            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void VoorlettersVanNamenMetR_selecteertAlleenNamenMetrOFR()
        {
            var target = new NamenManager(new List<string> { "Jan", "Marco", "Rouke" });

            IEnumerable<char> result = target.VoorlettersVanNamenMetR();

            List<char> expected = new List<char> { 'M', 'R' };
            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void AantalLettersVanNamenBeginnendMet_J_AflopendGesorteerd()
        {
            var target = new NamenManager(namen);

            IEnumerable<int> result = target.AantalLettersVanNamenBeginnendMet_J_AflopendGesorteerd();

            var expected = new List<int> { 8, 6, 5, 5, 3 };
            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void AantalNamenMetPerAantalLetters()
        {
            var target = new NamenManager(namen);

            IEnumerable<int> result = target.AantalNamenMetPerAantalLetters();

            var expected = new List<int> { 4, 4, 6, 5, 3, 1, 1 };
            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void AlleKortsteNamenZonderA_AlfabetischGesorteerdTest()
        {
            var target = new NamenManager(namen);

            IEnumerable<string> result = target.AlleKortsteNamenZonderA_AlfabetischGesorteerd();

            var expected = new List<string> { "Pim", "Rob" };
            CollectionAssert.AreEqual(expected, result.ToList());
        }
    }
}
