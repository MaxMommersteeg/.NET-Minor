using Microsoft.AspNetCore.Mvc;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using System;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService.Models;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Facade.Configuration;
using Microsoft.Extensions.Options;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Controllers
{
    public class ApkController : Controller
    {
        private readonly IOptions<WebAppConfig> _settings;
        private readonly IRdwIntegrationServiceAgent _rdwIntegrationServiceAgent;
        private readonly IRepository<Onderhoudsopdracht, long> _onderhoudsopdrachtRepository;
        private readonly ILogService _logger;


        public ApkController(IRdwIntegrationServiceAgent rdwIntegrationServiceAgent, IRepository<Onderhoudsopdracht, long> onderhoudsopdrachtRepository, ILogService logger, IOptions<WebAppConfig> settings)
        {
            _rdwIntegrationServiceAgent = rdwIntegrationServiceAgent;
            _onderhoudsopdrachtRepository = onderhoudsopdrachtRepository;
            _settings = settings;
            _logger = logger;
        }

        /// <summary>
        /// Default Index page for controller
        /// </summary>
        /// <param name="apkAanvraag"></param>
        /// <returns></returns>
        public IActionResult Index(long onderhoudsopdrachtId)
        {
            var model = new ApkAanvraagViewModel();
            // If OnderhoudsopdrachtId was passed, check if we can find it and use it to fill form in advance
            var opdrachtExists = _onderhoudsopdrachtRepository.Exists(onderhoudsopdrachtId);
            if(!opdrachtExists)
            {
                return RedirectToAction("Index", "Onderhoudsopdrachten");
            }
            var opdracht = _onderhoudsopdrachtRepository.Find(onderhoudsopdrachtId);
            model = new ApkAanvraagViewModel()
            {
                OndehoudsopdrachtId = opdracht.OnderhoudsId,
                Kenteken = opdracht.Kenteken,
                Kilometerstand = opdracht.Kilometerstand,
                EigenaarAuto = opdracht.Bestuuder
                
            };
            return View(model);
        }

        /// <summary>
        /// Processes ApkAanvraag ViewModels and if corrects posts to Rdw Integration Service
        /// </summary>
        /// <param name="apkAanvraag"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendApkAanvraag(ApkAanvraagViewModel apkAanvraag)
        {
            // Validate ApkAanvraag ViewModel
            if (!ModelState.IsValid)
            {
                return View("Index", apkAanvraag);
            }

            // ModelState is valid
            var apkKeuringsVerzoekCommand = CreateApkKeuringsVerzoekCommand(apkAanvraag);
            object keuringsVerzoekResult;
            try
            {
                keuringsVerzoekResult = _rdwIntegrationServiceAgent.MakeApkRequest(apkKeuringsVerzoekCommand);
            }
            catch(Exception ex)
            {
                _logger.LogException(new LogMessage(ex.Message, ex.StackTrace));
                ViewData["FeedbackMessage"] = "Sorry, de service is op dit niet beschikbaar. Probeer het later opnieuw.";
                return View("Index", apkAanvraag);
            }

            if (!(keuringsVerzoekResult is KeuringsVerzoekAntwoord))
            {
                return RedirectToAction("Index", apkAanvraag);
            }

            KeuringsVerzoekAntwoord keuringsVerzoekAntwoord = (KeuringsVerzoekAntwoord)keuringsVerzoekResult;
            if (keuringsVerzoekAntwoord.IsSteekProef == true)
            {
                var steekProefViewModel = new SteekproefViewModel(keuringsVerzoekAntwoord.SteepkProefDate);
                return View("SteekProef", steekProefViewModel);
            }
            return View("AutoAfgemeld");
        }

        private ApkKeuringsVerzoekCommand CreateApkKeuringsVerzoekCommand(ApkAanvraagViewModel apkAanvraag)
        {
            var apkKeuringsVerzoekCommand = new ApkKeuringsVerzoekCommand()
            {
                OnderhoudsBeurtId = apkAanvraag.OndehoudsopdrachtId,
                Kenteken = apkAanvraag.Kenteken,
                Kilometerstand = apkAanvraag.Kilometerstand,
                EigenaarNaam = apkAanvraag.EigenaarAuto,
                VoertuigType = apkAanvraag.VoertuigType,
                KeuringsDatum = DateTime.UtcNow,
                KeuringsinstantieKvkNummer = _settings.Value.KvkNummer,
                KeuringsinstantieType = _settings.Value.InstantieType,
                Bedrijfsnaam = _settings.Value.BedrijfsNaam,
                BedrijfPlaats = _settings.Value.BedrijfsPlaats
            };
            return apkKeuringsVerzoekCommand;
        }

        /// <summary>
        /// Steekproef
        /// </summary>
        /// <param name="steekProefViewModel"></param>
        /// <returns></returns>
        public IActionResult Steekproef(SteekproefViewModel steekProefViewModel)
        {
            return View(steekProefViewModel);
        }

        /// <summary>
        /// AutoAfgemeld
        /// </summary>
        /// <returns></returns>
        public IActionResult AutoAfgemeld()
        {
            return View();
        }
    }
}
