using System;
using Microsoft.AspNetCore.Mvc;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService.Models;
using System.Linq;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Controllers
{
    public class OnderhoudsopdrachtenController : Controller
    {
        private readonly IRepository<Onderhoudsopdracht, long> _onderhoudsopdrachtRepository;
        private readonly IOnderhoudBeheerServiceAgent _onderhoudBeheerServiceAgent;
        private readonly ILogService _logger;

        public OnderhoudsopdrachtenController(IOnderhoudBeheerServiceAgent onderhoudBeheerServiceAgent, IRepository<Onderhoudsopdracht, long> onderhoudsopdrachtRepository, ILogService logger)
        {
            _onderhoudBeheerServiceAgent = onderhoudBeheerServiceAgent;
            _onderhoudsopdrachtRepository = onderhoudsopdrachtRepository;
            _logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {            
            // Load Entities
            var model = new OnderhoudsopdrachtenOverzichtViewModel();
            foreach (var opdracht in _onderhoudsopdrachtRepository.FindAll().OrderBy(x => x.OpdrachtAangemaakt).ToList())
            {
                model.Onderhoudsopdrachten.Add(new OnderhoudsopdrachtViewModel(opdracht));
            }
            return View(model);
        }

        public IActionResult Toevoegen()
        {
            return View(new OnderhoudsopdrachtViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendOnderhoudsopdracht(OnderhoudsopdrachtViewModel onderhoudsOpdracht)
        {
            // Validate ApkAanvraag ViewModel
            if (!ModelState.IsValid)
            {
                return View("Toevoegen", onderhoudsOpdracht);
            }

            // ModelState is valid
            var createOnderhoudCommand = MapCreateOnderhoudCommand(onderhoudsOpdracht);
            object createOnderhoudResult;
            try
            {
                createOnderhoudCommand.Validate();
                createOnderhoudResult = _onderhoudBeheerServiceAgent.AddOnderhoudsopdracht(createOnderhoudCommand);
            }
            catch(Exception ex)
            {
                _logger.LogException(new LogMessage(ex.Message, ex.StackTrace));

                ViewData["FeedbackMessage"] = "Sorry, de service is op dit niet beschikbaar. Probeer het later opnieuw.";
                return View("Toevoegen", onderhoudsOpdracht);
            }

            if ((createOnderhoudResult is InvalidRequest))
            {
                ViewData["FeedbackMessage"] = "Sorry, de opdracht kon niet verwerkt worden. Probeer het later opnieuw.";
                return RedirectToAction("Toevoegen", onderhoudsOpdracht);
            }
            return RedirectToAction("OnderhoudsopdrachtToegevoegd");
        }

        public IActionResult OnderhoudsopdrachtToegevoegd()
        {
            return View();
        }

        private CreateOnderhoudCommand MapCreateOnderhoudCommand(OnderhoudsopdrachtViewModel onderhoudsOpdracht)
        {
            CreateOnderhoudCommand createOnderhoudCommand = new CreateOnderhoudCommand()
            {
                Kenteken = onderhoudsOpdracht.Kenteken,
                Kilometerstand = onderhoudsOpdracht.Kilometerstand,
                OnderhoudsBeschrijving = onderhoudsOpdracht.OnderhoudOmschrijving,
                OpdrachtAangemaakt = DateTime.UtcNow,
                HasApk = onderhoudsOpdracht.IsAPKKeuring,
                Bestuurder = onderhoudsOpdracht.BestuurderNaam,
                TelefoonNrBestuurder = onderhoudsOpdracht.TelefoonNrBestuurder
            };
            return createOnderhoudCommand;
        }
    }
}
