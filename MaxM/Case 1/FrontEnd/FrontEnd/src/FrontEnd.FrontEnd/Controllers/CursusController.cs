using Microsoft.AspNetCore.Mvc;
using FrontEnd.ViewModels.Cursus;
using System;
using FrontEnd.Agents;
using System.Linq;
using System.Collections.Generic;
using FrontEnd.Agents.Models;
using FrontEnd.Parsers;
using FrontEnd.Extensions;

namespace FrontEnd.Controllers {
    public class CursusController : Controller {
        private const string CURSUS_FILE_ERRORS_TITLE = "CursusFileErrorsTitle";
        private const string CURSUS_FILE_ERRORS = "CursusFileErrors";
        private const string CURSUS_FILE_DUPLICATES_TITLE = "CursusFileDuplicatesTitle";
        private const string CURSUS_FILE_DUPLICATES = "CursusFileDuplicates";
        private const string CURSUS_FILE_IMPORTED_TITLE = "CursusFileImportedTitle";
        private const string CURSUS_FILE_IMPORTED = "CursusFileImported";

        private readonly ICASService _casService;
        private readonly ICursusFileParser _cursusFileParser;

        /// <summary>
        /// CursusController
        /// </summary>
        /// <param name="casService">ICASService</param>
        /// <param name="cursusFileParser">ICursusFileParser</param>
        public CursusController(ICASService casService, ICursusFileParser cursusFileParser) {
            _casService = casService;
            _cursusFileParser = cursusFileParser;
        }

        /// <summary>
        /// Index
        /// Retrieves a list of cursussen for current week, or given year and weeknumber if set
        /// </summary>
        /// <param name="year">year int not required</param>
        /// <param name="weeknumber">weeknumber int not required</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int? year, int? weeknumber) {
            var cursusListViewModel = new CursusListViewModel();

            // If year has a value, check if it is a valid one
            if (year.HasValue) {
                if (Convert.ToInt32(cursusListViewModel.Years.Last().Value) < year || Convert.ToInt32(cursusListViewModel.Years.First().Value) > year) {
                    year = null;
                }
            }

            // If weeknumber has a value, check if it is a valid one
            if (weeknumber.HasValue) {
                if (weeknumber < 1 || weeknumber > 53) {
                    weeknumber = null;
                }
            }

            // Check if year and weeknumber have been set, if not, 
            var selectedWeekNumber = weeknumber ?? DateTime.Now.GetIso8601WeekOfYear();
            var selectedYear = year ?? DateTime.Now.Year;
            var cursussen = _casService.ApiV1CursusByYearByWeeknumberGet(selectedWeekNumber, selectedYear) as List<Cursus>;

            // Initialize model
            cursusListViewModel
                .Cursussen = cursussen.Select(x => new CursusViewModel {
                    Id = x.Id.Value, Title = x.Title,
                    StartDate = x.StartDate, DateCount = x.AmountOfDays, CursistCount = x.AmountOfCursisten
                }).ToList();
            cursusListViewModel.WeekNumber = selectedWeekNumber;
            cursusListViewModel.Year = selectedYear;

            return View(cursusListViewModel);
        }

        /// <summary>
        /// UploadCursusFile (GET)
        /// Presents view for uploading CursusFile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UploadCursusFile() {
            var model = new UploadCursusFileViewModel();
            return View(model);
        }

        /// <summary>
        /// UploadCursusFile (POST)
        /// Processes the UploadCursusFileViewModel
        /// </summary>
        /// <param name="cursusFile"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadCursusFile(UploadCursusFileViewModel uploadCursusViewModel, bool cbUseDateRange = true) {
            // Check if given UploadCursusFileViewModel model is valid
            if (!ModelState.IsValid) {
                return View(uploadCursusViewModel);
            }

            if(!cbUseDateRange) {
                uploadCursusViewModel.StartDate = DateTime.MinValue;
                uploadCursusViewModel.EndDate = DateTime.MaxValue;
            }

            ParsedCursusFileResultContainer parsedCursusFileResultContainer;
            try {
                parsedCursusFileResultContainer = _cursusFileParser.GetCursussenFromCursusFile(uploadCursusViewModel.CursusFile, uploadCursusViewModel.StartDate, uploadCursusViewModel.EndDate);
            } catch
            {
                return View(uploadCursusViewModel);
            }
            // Check if we stumbled on errors
            if (parsedCursusFileResultContainer.ErrorMessages.Count > 0) {
                ViewData[CURSUS_FILE_ERRORS_TITLE] = $"{parsedCursusFileResultContainer.ErrorMessages.Count} fout(en) gevonden:";
                foreach (var errorMessage in parsedCursusFileResultContainer.ErrorMessages) {
                    ModelState.AddModelError(CURSUS_FILE_ERRORS, errorMessage);
                }
                return View(uploadCursusViewModel);
            }

            // Check if we stumbled on duplicates
            if (parsedCursusFileResultContainer.DuplicateCursussen.Count > 0) {
                ViewData[CURSUS_FILE_DUPLICATES_TITLE] = $"{parsedCursusFileResultContainer.DuplicateCursussen.Count} dubbele cursus(sen) gevonden:";
                foreach (var duplicate in parsedCursusFileResultContainer.DuplicateCursussen) {
                    ModelState.AddModelError(CURSUS_FILE_DUPLICATES, $"Duplicaat: {duplicate.CursusCode} met datum: {duplicate.StartDate.Date.ToString("dd/MM/yyyy")}");
                }
            }

            uploadCursusViewModel.CursusImportedFeedbackViewModel = new CursusImportedFeedbackViewModel("Aantal cursus(sen) toegevoegd", parsedCursusFileResultContainer.ParsedCursussen.Count);

            // Post valid cursussen
            foreach (var cursus in parsedCursusFileResultContainer.ParsedCursussen) {
                ModelState.AddModelError(CURSUS_FILE_IMPORTED, $"Titel: {cursus.Title}, Cursuscode: {cursus.CursusCode}, Startdatum: {cursus.StartDate.Date.ToString("dd/MM/yyyy")}");
                _casService.Post(cursus);
            }

            return View(uploadCursusViewModel);
        }
    }
}