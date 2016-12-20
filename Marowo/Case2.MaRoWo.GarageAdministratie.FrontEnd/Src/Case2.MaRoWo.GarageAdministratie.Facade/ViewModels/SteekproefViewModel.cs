using System;

namespace Case2.MaRoWo.GarageAdministratie.Facade.ViewModels
{
    public class SteekproefViewModel
    {
        public SteekproefViewModel()
        {

        }

        public SteekproefViewModel(DateTime? steekproefDateTime = null)
        {
            SteekproefDateTime = steekproefDateTime;
        }
        public DateTime? SteekproefDateTime { get; set; }
    }
}
