using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands
{
    public class OnderhoudAfmeldenCommand
    {
        [Required]
        public long OnderhoudsId { get; set; }
    }
}
