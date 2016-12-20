using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Monument
    {
        public long ID { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Stad { get; set; }
    }
}
