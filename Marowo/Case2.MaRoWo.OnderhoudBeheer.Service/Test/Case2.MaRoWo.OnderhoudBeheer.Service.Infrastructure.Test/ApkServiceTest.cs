using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Dispatchers;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Test.Repositories;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Services;
using Moq;
using Minor.RoWe.Common.Interfaces;
using Minor.RoWe.Common.Events;
using Minor.Case2.Events.RDWIntegration;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Test
{
    [TestClass]
    public class ApkServiceTest
    {
        private DbContextOptions<OnderhoudBeheerContext> _options;

        [TestInitialize]
        public void StartUp()
        {            
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();
            using (var context = new OnderhoudBeheerContext(_options, true))
            {
                // recreate the database
            }
        }

        [TestMethod]
        public void HandleApkRequestWithSteekproef()
        {

            
            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            pubMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));
            var service = new ApkEventService(_options, pubMock.Object);

            long id = -1;
            using (var context = new OnderhoudBeheerContext(_options))
            using (var repo = new OnderhoudsopdrachtRepository(context))
            {
                id = repo.Insert(new Onderhoudsopdracht()
                {
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    OpdrachtStatus = OpdrachtStatussen.Aangemeld().StatusId,
                    OpdrachtStatusBeschrijving = OpdrachtStatussen.Aangemeld().Beschrijving,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "1232323"
                });
            }


            var apkEvent = new ApkAfgemeldEvent();
            apkEvent.CorrelationID = new Guid();
            apkEvent.HasSteekProef = true;
            apkEvent.Kenteken = "12-12-12";
            apkEvent.SteekProefDatum = new DateTime(2016, 12, 12);
            apkEvent.TimeStamp = new DateTime();
            apkEvent.RoutingKey = "test";
            apkEvent.OnderhoudsBeurtId = id;

            service.HandlerApkEvent(apkEvent);

            pubMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once);

            using (var context = new OnderhoudBeheerContext(_options))
            using (var repo = new OnderhoudsopdrachtRepository(context))
            {
                var opdracht = repo.Find(id);
                Assert.AreEqual(OpdrachtStatussen.Klaargemeld().StatusId, opdracht.OpdrachtStatus);
                Assert.AreEqual(OpdrachtStatussen.Klaargemeld().Beschrijving, opdracht.OpdrachtStatusBeschrijving);
            }

        }



        [TestMethod]
        public void HandleApkRequestWithoutSteekproef()
        {

           
            var pubMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            pubMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));
            var service = new ApkEventService(_options, pubMock.Object);

            long id = -1;
            using (var context = new OnderhoudBeheerContext(_options))
            using (var repo = new OnderhoudsopdrachtRepository(context))
            {
                id = repo.Insert(new Onderhoudsopdracht()
                {                    
                    Kenteken = "AA-BB-11",
                    HasApk = true,
                    Kilometerstand = 100,
                    OnderhoudsBeschrijving = "Achterlicht links vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    OpdrachtStatus = OpdrachtStatussen.Aangemeld().StatusId,
                    OpdrachtStatusBeschrijving = OpdrachtStatussen.Aangemeld().Beschrijving,
                    Bestuurder = "Jan",
                    TelefoonNrBestuurder = "+49 06 123123321"
               
                });
            }


            var apkEvent = new ApkAfgemeldEvent();
            apkEvent.CorrelationID = new Guid();
            apkEvent.HasSteekProef = false;
            apkEvent.Kenteken = "12-12-12";
            apkEvent.TimeStamp = new DateTime();
            apkEvent.RoutingKey = "test";
            apkEvent.OnderhoudsBeurtId = id;
                        
            service.HandlerApkEvent(apkEvent);

            pubMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once);

            using (var context = new OnderhoudBeheerContext(_options))
            using (var repo = new OnderhoudsopdrachtRepository(context))
            {
                var opdracht = repo.Find(id);
                Assert.AreEqual(OpdrachtStatussen.Afgemeld().StatusId, opdracht.OpdrachtStatus);
                Assert.AreEqual(OpdrachtStatussen.Afgemeld().Beschrijving, opdracht.OpdrachtStatusBeschrijving);
            }

        }
    }
}
