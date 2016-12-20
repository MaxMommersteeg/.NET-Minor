using System;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands
{
    public class UpdateOnderhoudCommand
    {
        [Required]
        public long OnderhoudsId { get; set; }

        [Required]
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
    }
}
