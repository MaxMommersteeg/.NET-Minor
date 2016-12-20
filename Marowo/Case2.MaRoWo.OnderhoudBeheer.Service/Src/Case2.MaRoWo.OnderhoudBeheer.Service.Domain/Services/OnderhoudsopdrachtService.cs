using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Infrastructure;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen;
using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Minor.Case2.Events.OnderhoudBeheer.Service;
using Minor.RoWe.Common.Interfaces;
using System;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services
{
    public class OnderhoudsopdrachtService : IOnderhoudsopdrachtService
    {
        private readonly IRepository<Onderhoudsopdracht, long> _onderhoudsopdrachtRepository;
        private readonly IEventPublisher _eventPublisher;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="onderhoudsopdrachtRepository"></param>
        /// <param name="eventPublisher"></param>
        public OnderhoudsopdrachtService(IRepository<Onderhoudsopdracht, long> onderhoudsopdrachtRepository, IEventPublisher eventPublisher)
        {
            _onderhoudsopdrachtRepository = onderhoudsopdrachtRepository;
            _eventPublisher = eventPublisher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoudCommand"></param>
        public void AddOnderhoudsopdracht(CreateOnderhoudCommand onderhoudCommand)
        {
            // Map onderhoudCommand to a valid Onderhoudsopdracht entity
            var opdracht = new Onderhoudsopdracht
            {
                HasApk = onderhoudCommand.HasApk,
                Kenteken = onderhoudCommand.Kenteken,
                Kilometerstand = onderhoudCommand.Kilometerstand,
                OnderhoudsBeschrijving = onderhoudCommand.OnderhoudsBeschrijving,
                OpdrachtAangemaakt = onderhoudCommand.OpdrachtAangemaakt,
                OpdrachtStatus = OpdrachtStatussen.Aangemeld().StatusId,
                OpdrachtStatusBeschrijving = OpdrachtStatussen.Aangemeld().Beschrijving,
                Bestuurder = onderhoudCommand.Bestuurder,
                TelefoonNrBestuurder = onderhoudCommand.TelefoonNrBestuurder
                
            };

            // Persist data using repository and store key after insert
            var opdrachtId = _onderhoudsopdrachtRepository.Insert(opdracht);

            // Map opdracht to OnderhoudsopdrachtCreatedEvent
            var opdrachtCreatedEvent = new OnderhoudsopdrachtCreatedEvent
            {
                RoutingKey = "Minor.Case2.MaRoWo.OnderhoudsBeheer.OnderhoudsopdrachtCreated",
                TimeStamp = DateTime.UtcNow,
                CorrelationID = Guid.NewGuid(),
                OnderhoudsBeurtId = opdrachtId,
                HasApk = opdracht.HasApk,
                Kenteken = opdracht.Kenteken,
                Kilometerstand = opdracht.Kilometerstand,
                OnderhoudsBeschrijving = opdracht.OnderhoudsBeschrijving,
                OpdrachtAangemaakt = opdracht.OpdrachtAangemaakt,
                OpdrachtStatus = opdracht.OpdrachtStatus,
                OpdrachtStatusBeschrijving = opdracht.OpdrachtStatusBeschrijving,
                Bestuurder = opdracht.Bestuurder,
                TelefoonNrBestuurder = opdracht.TelefoonNrBestuurder
            };

            // Publish event "OnderhoudCreatedEvent"
            _eventPublisher.Publish(opdrachtCreatedEvent);
        }

        public void UpdateOnderhoudsopdracht(UpdateOnderhoudCommand updateOnderhoudCommand)
        {
            // Map onderhoudCommand to a valid Onderhoudsopdracht entity
            var opdracht = new Onderhoudsopdracht
            {
                Id = updateOnderhoudCommand.OnderhoudsId,
                Kenteken = updateOnderhoudCommand.Kenteken,
                Kilometerstand = updateOnderhoudCommand.Kilometerstand,
                OnderhoudsBeschrijving = updateOnderhoudCommand.OnderhoudsBeschrijving,
                HasApk = updateOnderhoudCommand.HasApk,
                OpdrachtAangemaakt = updateOnderhoudCommand.OpdrachtAangemaakt
            };

            // Persist data using repository and store key after insert
            _onderhoudsopdrachtRepository.Update(opdracht);

            var opdrachtUpdatedEvent = CreateUpdateEvent(opdracht);
            _eventPublisher.Publish(opdrachtUpdatedEvent);
        }

        public void OnderhoudsopdrachtAfmelden(OnderhoudAfmeldenCommand onderhoudAfmeldenCommand)
        {
            // Map onderhoudCommand to a valid Onderhoudsopdracht entity
            if (!_onderhoudsopdrachtRepository.Exists(onderhoudAfmeldenCommand.OnderhoudsId))
            {
                throw new ArgumentException("Opgegeven Id is niet gevonden in de database");
            }
            var opdracht = _onderhoudsopdrachtRepository.Find(onderhoudAfmeldenCommand.OnderhoudsId);
            opdracht.OpdrachtStatus = OpdrachtStatussen.Afgemeld().StatusId;
            opdracht.OpdrachtStatusBeschrijving = OpdrachtStatussen.Afgemeld().Beschrijving;

            // Persist data using repository and store key after insert
            _onderhoudsopdrachtRepository.Update(opdracht);
            OnderhoudsopdrachtUpdatedEvent opdrachtUpdatedEvent = CreateUpdateEvent(opdracht);
            _eventPublisher.Publish(opdrachtUpdatedEvent);
        }

        private OnderhoudsopdrachtUpdatedEvent CreateUpdateEvent(Onderhoudsopdracht opdracht)
        {
            return new OnderhoudsopdrachtUpdatedEvent
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
                TelefoonNrBestuurder = opdracht.TelefoonNrBestuurder
            };
        }
    }
}
