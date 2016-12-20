using System.Collections.Generic;

namespace Case2.MaRoWo.GarageAdministratie.Facade.ViewModels
{
    public class OnderhoudsopdrachtenOverzichtViewModel
    {
        public OnderhoudsopdrachtenOverzichtViewModel()
        {
            Onderhoudsopdrachten = new List<OnderhoudsopdrachtViewModel>();
        }

        public List<OnderhoudsopdrachtViewModel> Onderhoudsopdrachten { get; set; }
    }
}
