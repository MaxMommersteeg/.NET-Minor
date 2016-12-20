using System.ComponentModel.DataAnnotations;

namespace TemplateCoreConsoleApplication.Test
{
    public class Naaktslak
    {
        public long ID { get; set; }
        [Required]
        [StringLength(64)]
        public string Soortnaam { get; set; }
        public double Slijmviscociteit { get; set; }
        public double Snelheid { get; set; }
    }
}