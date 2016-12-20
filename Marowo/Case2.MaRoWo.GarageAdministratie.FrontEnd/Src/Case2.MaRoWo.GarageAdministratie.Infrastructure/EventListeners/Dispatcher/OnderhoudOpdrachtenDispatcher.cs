using Minor.RoWe.Eventbus.Dispatchers;
using System;
using Minor.RoWe.Eventbus.Connectors;
using Microsoft.EntityFrameworkCore;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Minor.Case2.Events.OnderhoudBeheer.Service;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using System.Diagnostics;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.EventListeners.Dispathers
{
    public class OnderhoudOpdrachtenDispatcher : EventDispatcher
    {
        private readonly DbContextOptions<GarageAdministratieContext> _options;

        public OnderhoudOpdrachtenDispatcher(IRabbitMqConnection connection, DbContextOptions<GarageAdministratieContext> options) : base(connection)
        {
            _options = options;
        }

        public override string RoutingKey
        {
            get
            {
                return "Minor.Case2.MaRoWo.OnderhoudsBeheer.#";
            }
        }

        public void CreatedEventHandler(OnderhoudsopdrachtCreatedEvent onderhoudOpdrachtCreatedEvent)
        {
            Onderhoudsopdracht onderhoudsOpdracht = new Onderhoudsopdracht()
            {
                OnderhoudsId = onderhoudOpdrachtCreatedEvent.OnderhoudsBeurtId,
                Kenteken = onderhoudOpdrachtCreatedEvent.Kenteken,
                Kilometerstand = onderhoudOpdrachtCreatedEvent.Kilometerstand,
                OnderhoudOmschrijving = onderhoudOpdrachtCreatedEvent.OnderhoudsBeschrijving,
                IsAPKKeuring = onderhoudOpdrachtCreatedEvent.HasApk,
                OpdrachtAangemaakt = onderhoudOpdrachtCreatedEvent.OpdrachtAangemaakt,
                OpdrachtStatus = onderhoudOpdrachtCreatedEvent.OpdrachtStatus,
                OpdrachtStatusBeschrijving = onderhoudOpdrachtCreatedEvent.OpdrachtStatusBeschrijving,
                Bestuuder = onderhoudOpdrachtCreatedEvent.Bestuurder,
                TelefoonNrBestuuder = onderhoudOpdrachtCreatedEvent.TelefoonNrBestuurder

            };
            InsertOrUpdateOnderhoudsopdracht(onderhoudsOpdracht);
        }

        public void UpdateEventHandler(OnderhoudsopdrachtUpdatedEvent onderhoudsopdrachtUpdatedEvent)
        {
            Onderhoudsopdracht onderhoudsOpdracht = new Onderhoudsopdracht()
            {
                OnderhoudsId = onderhoudsopdrachtUpdatedEvent.OnderhoudsBeurtId,
                Kenteken = onderhoudsopdrachtUpdatedEvent.Kenteken,
                Kilometerstand = onderhoudsopdrachtUpdatedEvent.Kilometerstand,
                OnderhoudOmschrijving = onderhoudsopdrachtUpdatedEvent.OnderhoudsBeschrijving,
                IsAPKKeuring = onderhoudsopdrachtUpdatedEvent.HasApk,
                OpdrachtAangemaakt = onderhoudsopdrachtUpdatedEvent.OpdrachtAangemaakt,
                OpdrachtStatus = onderhoudsopdrachtUpdatedEvent.OpdrachtStatus,
                OpdrachtStatusBeschrijving = onderhoudsopdrachtUpdatedEvent.OpdrachtStatusBeschrijving,
                Bestuuder = onderhoudsopdrachtUpdatedEvent.Bestuurder,
                TelefoonNrBestuuder = onderhoudsopdrachtUpdatedEvent.TelefoonNrBestuurder
            };
            InsertOrUpdateOnderhoudsopdracht(onderhoudsOpdracht);
        }

        private void InsertOrUpdateOnderhoudsopdracht(Onderhoudsopdracht onderhoudsOpdracht)
        {
            try
            {
                using (var context = new GarageAdministratieContext(_options))
                using (var repository = new OnderhoudsopdrachtenRepository(context))
                {
                    if (repository.Exists(onderhoudsOpdracht.OnderhoudsId))
                    {
                        Debug.WriteLine("Updating");
                        repository.Update(onderhoudsOpdracht);
                    }
                    else
                    {
                        Debug.WriteLine("Inserting");
                        repository.Insert(onderhoudsOpdracht);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
