using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGRepoEFDB;

namespace RPGRepoEFDB.Test
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void OphalenAlleRPGsEersteTest()
        {
            //Arrange
            RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB();

            //Act
            List<RPG> RPGs = RPGRepo.FindAll().ToList();

            //Assert
            Assert.AreEqual(0, RPGs.Count());

        }

        [TestMethod]
        public void OphalenAlleRPGsInvoegenEnDanCount1()
        {
            //Arrange
            RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB();

            RPGRepo.Insert(new RPG());


            //Act
            List<RPG> RPGs = RPGRepo.FindAll().ToList();

            //Assert
            Assert.AreEqual(1, RPGs.Count());

        }
    }
}
