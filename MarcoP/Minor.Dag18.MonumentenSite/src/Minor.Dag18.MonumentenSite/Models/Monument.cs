using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag18.MonumentenSite.Models
{
    public class Monument
    {
        public long ID { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        [RegularExpression(@"(Pa|Be)rl?i[ns]", ErrorMessage = "De Stad moet Paris of Berlin zijn, of iets wat daar veel op lijkt")]
        public string Stad { get; set; }
    }
}
