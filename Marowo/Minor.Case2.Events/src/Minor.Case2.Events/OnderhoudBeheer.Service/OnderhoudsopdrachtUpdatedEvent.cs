using Minor.RoWe.Common.Events;
using System;

namespace Minor.Case2.Events.OnderhoudBeheer.Service
{
    public class OnderhoudsopdrachtUpdatedEvent : DomainEvent
    {
        public long OnderhoudsBeurtId { get; set; }
        public string Kenteken { get; set; }
        public int Kilometerstand { get; set; }
        public string OnderhoudsBeschrijving { get; set; }
        public bool HasApk { get; set; }
        public DateTime OpdrachtAangemaakt { get; set; }
        public int OpdrachtStatus { get; set; }
        public string OpdrachtStatusBeschrijving { get; set; }

        public string Bestuurder { get; set; }
        public string TelefoonNrBestuurder { get; set; }
    }
}
