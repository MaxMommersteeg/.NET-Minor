using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.GarageAdministratie.Facade.ViewModels
{
    public class OnderhoudsopdrachtViewModel
    {
        public OnderhoudsopdrachtViewModel()
        {

        }

        public OnderhoudsopdrachtViewModel(Onderhoudsopdracht onderhoudsopdrachtEntity)
        {
            Id = onderhoudsopdrachtEntity.Id;
            OnderhoudsId = onderhoudsopdrachtEntity.OnderhoudsId;
            Kenteken = onderhoudsopdrachtEntity.Kenteken;
            Kilometerstand = onderhoudsopdrachtEntity.Kilometerstand;
            OnderhoudOmschrijving = onderhoudsopdrachtEntity.OnderhoudOmschrijving;
            IsAPKKeuring = onderhoudsopdrachtEntity.IsAPKKeuring;
            OpdrachtAangemaakt = onderhoudsopdrachtEntity.OpdrachtAangemaakt;
            OpdrachtStatusId = onderhoudsopdrachtEntity.OpdrachtStatus;
            OpdrachtStatusBeschrijving = onderhoudsopdrachtEntity.OpdrachtStatusBeschrijving;
            BestuurderNaam = onderhoudsopdrachtEntity.Bestuuder;
            TelefoonNrBestuurder = onderhoudsopdrachtEntity.TelefoonNrBestuuder;
        }

        public long Id { get; set; }

        public long OnderhoudsId { get; set; }

        [Display(Name = "Kenteken")]
        [Required(ErrorMessage = "Kenteken is verplicht")]
        [StringLength(50)]
        public string Kenteken { get; set; }

        [Display(Name = "Kilometerstand (KM)")]
        [Range(0, int.MaxValue, ErrorMessage = "Kilometerstand moet minimaal 0 zijn")]
        public int Kilometerstand { get; set; }

        [Display(Name = "Onderhoud omschrijving")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Onderhoud omschrijving moet tussen de 5 en 200 tekens bevatten")]
        [Required(ErrorMessage = "Onderhoud omschrijving is verplicht")]
        public string OnderhoudOmschrijving { get; set; }

        [Required(ErrorMessage = "Er moet worden aangegeven of een APK Keuring van toepassing is")]
        [Display(Name = "Met APK Keuring")]
        public bool IsAPKKeuring { get; set; }

        [Display(Name = "Aangemaakt op")]
        public DateTime OpdrachtAangemaakt { get; set; }

        public int OpdrachtStatusId { get; set; }

        [Display(Name = "Opdracht status")]
        public string OpdrachtStatusBeschrijving { get; set; }

        [Required(ErrorMessage = "Bestuuder is verplicht")]
        [Display(Name = "Bestuurder")]
        [StringLength(300)]
        public string BestuurderNaam { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [Display(Name = "TelefoonNr")]
        [StringLength(150)]
        public string TelefoonNrBestuurder { get; set; }
    }
}
