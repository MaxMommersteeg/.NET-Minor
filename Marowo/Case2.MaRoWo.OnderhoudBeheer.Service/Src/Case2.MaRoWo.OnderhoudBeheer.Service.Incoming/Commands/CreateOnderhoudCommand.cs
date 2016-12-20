using System;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands
{
    public class CreateOnderhoudCommand
    {
        [Required]
        [StringLength(50)]
        public string Kenteken { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Kilometerstand { get; set; }

        [Required]
        public string OnderhoudsBeschrijving { get; set; }

        [Required]
        public bool HasApk { get; set; }

        [Required]
        public DateTime OpdrachtAangemaakt { get; set; }

        [Required]
        [StringLength(300)]
        public string Bestuurder { get; set; }

        [Required]
        [StringLength(150)]
        public string TelefoonNrBestuurder { get; set; }

        
        
    }
}
