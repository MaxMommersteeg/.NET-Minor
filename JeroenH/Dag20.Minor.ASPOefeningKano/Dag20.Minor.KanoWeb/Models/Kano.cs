using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dag20.Minor.KanoWeb.Models
{
    public class Kano
    {
        [Key]
        [Required]
        public int kanoID { get; set; }
        [EnumDataType(typeof(KanoTypes))]
        public KanoTypes kanoType { get; set; }

        public string kanoNaam { get; set; } 
    }
}
