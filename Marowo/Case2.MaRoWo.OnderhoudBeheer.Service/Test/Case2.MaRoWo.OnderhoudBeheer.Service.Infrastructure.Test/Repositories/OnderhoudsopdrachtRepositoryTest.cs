using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Test.Repositories
{
    [TestClass]
    public class OnderhoudsopdrachtRepositoryTest
    {
        private DbContextOptions _options;

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            //_options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();

            using (var context = new OnderhoudBeheerContext(_options, true))
            {
                // recreate the database
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryAddTest()
        {
            // Arrange - Act
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving ="Aangemeld"
                });
            }

            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryInsertReturnIncreasedTest()
        {
            // Arrange - Act
            long generatedId1 = -1;
            long generatedId2 = -1;
            long generatedId3 = -1;
            long generatedId4 = -1;
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                generatedId1 = repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
                generatedId2 = repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
                generatedId3 = repo.Insert(new Onderhoudsopdracht()
                {                    
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
                generatedId4 = repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
            }

            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                Assert.AreEqual(4, repo.Count());
                CollectionAssert.AreEqual(new List<long> { generatedId1, generatedId2, generatedId3, generatedId4 }, repo.FindAll().Select(x => x.Id).ToList());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryFindTest()
        {
            // Arrange
            string kenteken = "AA-BB-11";
            bool isApk = true;
            int kilometerstand = 100;
            string onderhoudsBeschrijving = "Accu vervangen";

            // Act
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                repo.Insert(new Onderhoudsopdracht()
                {
                    
                    Kenteken = kenteken,
                    HasApk = isApk,
                    Kilometerstand = kilometerstand,
                    OnderhoudsBeschrijving = onderhoudsBeschrijving,
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
            }

            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual(kenteken, result.Kenteken);
                Assert.AreEqual(isApk, result.HasApk);
                Assert.AreEqual(kilometerstand, result.Kilometerstand);
                Assert.AreEqual(onderhoudsBeschrijving, result.OnderhoudsBeschrijving);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryDeleteTest()
        {
            // Arrange
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                var opdracht = new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Voorwiel links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                };
                // Act
                repo.Insert(opdracht);
                repo.Delete(1);
            }

            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                Assert.AreEqual(0, repo.Count());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryFindAllTest()
        {
            // Arrange - Act
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                var opdracht1 = new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht rechts vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                };
                repo.Insert(opdracht1);
                var opdracht2 = new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 130,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                };
                repo.Insert(opdracht2);
            }

            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void OnderhoudsopdrachtRepositoryUpdateTest()
        {
            // Arrange
            string updatedOnderhoudsBeschrijving = "Bijgewerkte OnderhoudsBeschrijving";

            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 130,
                    OnderhoudsBeschrijving = "Spoiler vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "0315-12356",
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "Aangemeld"
                });
            }

            // Act
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                var item = repo.Find(1);


                item.Kenteken = "AA-BB-12";
                item.OnderhoudsBeschrijving = updatedOnderhoudsBeschrijving;
                repo.Update(item);
            };


            // Assert
            using (var repo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual(updatedOnderhoudsBeschrijving, repo.Find(1).OnderhoudsBeschrijving);
                Assert.AreEqual("AA-BB-12", repo.Find(1).Kenteken);
            }
        }
    }
}
