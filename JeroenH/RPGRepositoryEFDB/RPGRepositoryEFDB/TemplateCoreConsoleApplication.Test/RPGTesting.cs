using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG_EFDB;

namespace RPGRepositoryEFDB.Test
{
    [TestClass]
    public class RPGTesting
    {
        [TestMethod]
        public void GetAllRPGs()
        {
            RPGRepository RPGRepo = new RPGRepository();

            //Act
            RPG[] rpgs = RPGRepo.FindAll();

            //Assert
            Assert.AreEqual(0,rpgs.Count);

        }
    }
}
