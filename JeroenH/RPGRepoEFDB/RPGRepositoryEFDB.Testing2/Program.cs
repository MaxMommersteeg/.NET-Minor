using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGRepoEFDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace RPGRepoEFDB.Test
{
    [TestClass]
    public class Program
    {
        private static DbContextOptions<RPGContext> DBContextGenerator()
        {
            var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

            // Create options telling the context to use an
            // InMemory database and the service provider.
            var builder = new DbContextOptionsBuilder<RPGContext>();
            builder.UseInMemoryDatabase()
                       .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        [TestMethod]
        public void OphalenAlleRPGsEersteTest()
        {
            var options = DBContextGenerator();
            //Arrange
            using (var context = new RPGContext(options))
            {
                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);


            }
            using (var context = new RPGContext(options))
            {

                List<RPG> RPGs = context.RPGs.ToList();

                //Assert
                Assert.AreEqual(0, RPGs.Count());
            }

        }

        [TestMethod]
        public void OphalenAlleRPGsInvoegenEnDanCount1()
        {
            var options = DBContextGenerator();
            //Arrange
            using (var context = new RPGContext(options))
            {

                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);
                //Act
                RPGRepo.Insert(new RPG());
            }

            using (var context = new RPGContext(options))
            {

                List<RPG> RPGs = context.RPGs.ToList();

                //Assert
                Assert.AreEqual(1, RPGs.Count());
            }
        }

        [TestMethod]
        public void LijstRPGsOphalenOpBasisVanRPGSysteem()
        {
            var options = DBContextGenerator();
            //Arrange
            using (var context = new RPGContext(options))
            {

                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);
                //Act
                RPGRepo.Insert(new RPG { RPGSysteem = RPGSystemen.MistbornAdventureGame });
            }

            using (var context = new RPGContext(options))
            {
                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);

                List<RPG> RPGs = (List<RPG>) RPGRepo.FindBy(t=> t.RPGSysteem == RPGSystemen.MistbornAdventureGame);

                //Assert
                Assert.AreEqual(1, RPGs.Count());
            }
        }

        [TestMethod]
        public void LijstRPGsOphalenOpBasisVanRPGSysteemMeerdereInserts()
        {
            var options = DBContextGenerator();
            //Arrange
            using (var context = new RPGContext(options))
            {

                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);
                //Act
                RPGRepo.Insert(new RPG { RPGSysteem = RPGSystemen.MistbornAdventureGame });
                RPGRepo.Insert(new RPG ());
            }

            using (var context = new RPGContext(options))
            {
                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);

                List<RPG> RPGs = (List<RPG>)RPGRepo.FindBy(t => t.RPGSysteem == RPGSystemen.MistbornAdventureGame);

                //Assert
                Assert.AreEqual(1, RPGs.Count());
            }
        }

        [TestMethod]
        public void RPGToevoegenEnVervolgensVerwijderen()
        {
            var options = DBContextGenerator();
            //Arrange
            using (var context = new RPGContext(options))
            {

                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);

                RPG RPG = new RPG { RPGSysteem = RPGSystemen.MistbornAdventureGame };
                //Act
                RPGRepo.Insert(new RPG());




            }

            using (var context = new RPGContext(options))
            {
                RPGRepositoryEFDB RPGRepo = new RPGRepositoryEFDB(context);

                List<RPG> RPGs = (List<RPG>)RPGRepo.FindBy(t => t.RPGSysteem == RPGSystemen.MistbornAdventureGame);
                List<RPG> RPGs2 = (List<RPG>)RPGRepo.FindAll();
                //Assert
                Assert.AreEqual(0, RPGs.Count());
            }
        }
    }
}
