using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public class Koffie
    {
        [Display(Name = "Identifier")]
        public int Id { get; set; }
        [Display(Name = "Koffie naam")]
        public string Naam { get; set; }
        [Display(Name = "Minimale inhoud (CL)")]
        public double MinimaleInhoudInCl { get; set; }
        [Display(Name = "Maximale inhoud (CL)")]
        public double MaximaleInhoudInCl { get; set; }
    }
}
