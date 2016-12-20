using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Minor.Case2.Events.OnderhoudBeheer.Service;
using Minor.Case2.Events.RDWIntegration;
using Minor.RoWe.Common.Interfaces;
using System;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Services
{
    public class ApkEventService : IDisposable
    {
        private DbContextOptions<OnderhoudBeheerContext> _options;
        private IEventPublisher _publisher;

        public ApkEventService(DbContextOptions<OnderhoudBeheerContext> options, IEventPublisher publisher)
        {
            _options = options;
            _publisher = publisher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void HandlerApkEvent(ApkAfgemeldEvent e)
        {
            using (var context = new OnderhoudBeheerContext(_options))
            using (var repository = new OnderhoudsopdrachtRepository(context))
            {
                var opdracht = repository.Find(e.OnderhoudsBeurtId);

                OpdrachtStatus newState = e.HasSteekProef ? OpdrachtStatussen.Klaargemeld() : OpdrachtStatussen.Afgemeld();

                opdracht.OpdrachtStatus = newState.StatusId;
                opdracht.OpdrachtStatusBeschrijving = newState.Beschrijving;

                repository.Update(opdracht);

                var updateEvent = new OnderhoudsopdrachtUpdatedEvent()
                {
                    RoutingKey = "Minor.Case2.MaRoWo.OnderhoudsBeheer.OnderhoudsopdrachtUpdated",
                    TimeStamp = DateTime.UtcNow,
                    CorrelationID = Guid.NewGuid(),
                    OnderhoudsBeurtId = opdracht.Id,
                    HasApk = opdracht.HasApk,
                    Kenteken = opdracht.Kenteken,
                    Kilometerstand = opdracht.Kilometerstand,
                    OnderhoudsBeschrijving = opdracht.OnderhoudsBeschrijving,
                    OpdrachtAangemaakt = opdracht.OpdrachtAangemaakt,
                    OpdrachtStatus = opdracht.OpdrachtStatus,
                    OpdrachtStatusBeschrijving = opdracht.OpdrachtStatusBeschrijving,
                    Bestuurder = opdracht.Bestuurder,
                    TelefoonNrBestuurder =opdracht.TelefoonNrBestuurder
                };

                _publisher.Publish(updateEvent);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _publisher?.Dispose();
        }
    }
}
