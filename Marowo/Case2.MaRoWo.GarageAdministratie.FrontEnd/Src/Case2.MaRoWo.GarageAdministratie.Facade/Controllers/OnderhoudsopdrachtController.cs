using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Case2.MaRoWo.GarageAdministratie.Facade.Controllers
{
    public class OnderhoudsopdrachtController : Controller
    {
        private readonly IRepository<Onderhoudsopdracht, long> _onderhoudsopdrachtRepository;
        private readonly IOnderhoudBeheerServiceAgent _onderhoudBeheerServiceAgent;

        public OnderhoudsopdrachtController(IOnderhoudBeheerServiceAgent onderhoudBeheerServiceAgent, IRepository<Onderhoudsopdracht, long> onderhoudsopdrachtRepository)
        {
            _onderhoudsopdrachtRepository = onderhoudsopdrachtRepository;
            _onderhoudBeheerServiceAgent = onderhoudBeheerServiceAgent;
        }

        public IActionResult Index(long onderhoudsopdrachtId)
        {
            // If OnderhoudsopdrachtId was passed, check if we can find it and use it to fill form in advance
            bool opdrachtExists = _onderhoudsopdrachtRepository.Exists(onderhoudsopdrachtId);
            if (!opdrachtExists)
            {
                return RedirectToAction("Index", "Onderhoudsopdrachten");
            }
            var opdracht = _onderhoudsopdrachtRepository.Find(onderhoudsopdrachtId);
            var model = new OnderhoudsopdrachtViewModel(opdracht);
            return View(model);
        }

        public IActionResult OnderhoudsopdrachtUpdaten(long onderhoudsopdrachtId)
        {
            bool opdrachtExists = _onderhoudsopdrachtRepository.Exists(onderhoudsopdrachtId);
            if (!opdrachtExists)
            {
                return RedirectToAction("Index", "Onderhoudsopdrachten");
            }
            var opdracht = _onderhoudsopdrachtRepository.Find(onderhoudsopdrachtId);
            UpdateOnderhoudCommand updateOnderhoudCommand = new UpdateOnderhoudCommand()
            {
                OnderhoudsId = opdracht.OnderhoudsId,
                Kenteken = opdracht.Kenteken,
                Kilometerstand = opdracht.Kilometerstand,
                OnderhoudsBeschrijving = opdracht.OnderhoudOmschrijving,
                HasApk = opdracht.IsAPKKeuring,
                OpdrachtAangemaakt = opdracht.OpdrachtAangemaakt               
            };
            _onderhoudBeheerServiceAgent.UpdateOnderhoudsopdracht(updateOnderhoudCommand);
            return RedirectToAction("Index", "Onderhoudsopdrachten");
        }

        public IActionResult OnderhoudsopdrachtAfmelden(long onderhoudsopdrachtId)
        {
            bool opdrachtExists = _onderhoudsopdrachtRepository.Exists(onderhoudsopdrachtId);
            if (!opdrachtExists)
            {
                return RedirectToAction("Index", "Onderhoudsopdrachten");
            }
            var opdracht = _onderhoudsopdrachtRepository.Find(onderhoudsopdrachtId);
            OnderhoudAfmeldenCommand onderhoudAfmeldenCommand = new OnderhoudAfmeldenCommand()
            {
                OnderhoudsId = opdracht.OnderhoudsId,
            };
            _onderhoudBeheerServiceAgent.OnderhoudsopdrachtAfmelden(onderhoudAfmeldenCommand);
            return RedirectToAction("Index", "Onderhoudsopdrachten");
        }
    }
}
