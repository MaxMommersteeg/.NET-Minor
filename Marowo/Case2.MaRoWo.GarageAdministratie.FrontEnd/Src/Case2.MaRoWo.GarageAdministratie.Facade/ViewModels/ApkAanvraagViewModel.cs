using Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.GarageAdministratie.Facade.ViewModels
{
    public class ApkAanvraagViewModel
    {
        public readonly string[] VoertuigTypes = new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" };

        [Required]
        public long OndehoudsopdrachtId { get; set; }

        [Display(Name = "Voertuigtype")]
        // it looks like the static readonly VoertuigTypes can't be used as reference in the VoertuigTypeValidator
        [VoertuigTypeValidator("Onbekend voertuigtype ingevoerd", new string[] { "personenauto", "motor", "personenvervoer", "vrachtvervoer" })]
        [Required(ErrorMessage = "VoertuigType is verplicht")]
        public string VoertuigType { get; set; }

        [Display(Name = "Kenteken")]
        [Required(ErrorMessage = "Kenteken is verplicht")]
        public string Kenteken { get; set; }

        [Display(Name = "Kilometerstand (KM)")]
        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Kilometerstand is verplicht")]
        public int Kilometerstand { get; set; }

        [Display(Name = "Auto eigenaar")]
        [StringLength(200, MinimumLength = 3)]
        [Required(ErrorMessage = "Naam van de auto eigenaar is verplicht")]
        public string EigenaarAuto { get; set; }
    }
}
