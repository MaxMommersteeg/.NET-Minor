using Case2.MaRoWo.GarageAdministratie.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities
{
    public class Onderhoudsopdracht
    {
        public long Id { get; set; }

        [Required]
        public long OnderhoudsId { get; set; }

        [Required]
        [StringLength(50)]
        public string Kenteken { get; set; }

        [Range(0, int.MaxValue)]
        public int Kilometerstand { get; set; }

        [StringLength(200, MinimumLength = 5)]
        [Required]
        public string OnderhoudOmschrijving { get; set; }

        [Required]
        public bool IsAPKKeuring { get; set; }

        [Required]
        public DateTime OpdrachtAangemaakt { get; set; }

        [Required]
        public int OpdrachtStatus { get; set; }

        [Required]
        public string OpdrachtStatusBeschrijving { get; set; }

        [Required]
        [StringLength(150)]
        public string TelefoonNrBestuuder { get; set; }

        [Required]
        [StringLength(300)]
        public string Bestuuder { get; set; }
    }
}
