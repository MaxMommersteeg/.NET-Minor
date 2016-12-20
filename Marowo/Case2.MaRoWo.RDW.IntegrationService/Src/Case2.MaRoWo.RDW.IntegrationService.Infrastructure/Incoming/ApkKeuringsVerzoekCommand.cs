using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming
{
    public class ApkKeuringsVerzoekCommand
    {
        #region Voertuig props
        [Required]
        public string Kenteken { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Kilometerstand { get; set; }

        [Required]
        public string EigenaarNaam { get; set; }
       
        [Required]         
        [VoertuigTypeValidator]
        public string VoertuigType { get; set; }
        #endregion


        #region apk props

        [Required]
        [DateValidator]      
        public DateTime KeuringsDatum { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 8)]
        public string KeuringsinstantieKvkNummer { get; set; }

        [Required]
        public string KeuringsinstantieType { get; set; } 

        [Required]
        public string Bedrijfsnaam { get; set; }

        [Required]
        public string BedrijfPlaats { get; set; }
        
        [Required]
        public long OnderhoudsBeurtId { get;  set; }

        #endregion
    }
}


