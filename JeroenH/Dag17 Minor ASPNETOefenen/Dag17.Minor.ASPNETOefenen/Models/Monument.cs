using System.ComponentModel.DataAnnotations;

namespace Dag17.Minor.ASPNETOefenen
{
    public class Monument
    {
        [RegularExpression(@"\w*")]
        public string MonumentNaam { get; set; }
    }
}