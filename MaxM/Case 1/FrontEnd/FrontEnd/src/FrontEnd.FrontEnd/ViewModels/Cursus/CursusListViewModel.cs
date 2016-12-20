using FrontEnd.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FrontEnd.ViewModels.Cursus
{
    public class CursusListViewModel : IPageHeader
    {
        private const string TITLE = "Cursussen";
        private const int START_YEAR = 1980;
        private const int YEAR_LEAD = 10;
        private const int FIRST_WEEKNUMBER = 1;
        private const int LAST_WEEKNUMBER = 53;

        /// <summary>
        /// CursusListViewModel Constructor
        /// </summary>
        public CursusListViewModel()
        {
            // Initialize Years SelectList with values
            InitializeYearsSelectList();
            // Initialize WeekNumbers SelectList with values
            InitializeWeekNumbersSelectList();
            Cursussen = new List<CursusViewModel>();
        }

        [Display(Name = "Jaar", Description = "Selecteer een jaar")]
        public int Year { get; set; }

        [Display(Name = "Weeknummer", Description = "Selecteer een week")]
        public int WeekNumber { get; set; }

        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> WeekNumbers { get; set; }

        public IList<CursusViewModel> Cursussen { get; set; }

        /// <summary>
        /// GetTitle
        /// </summary>
        /// <returns>PageHeaderTitle</returns>
        public string GetTitle()
        {
            return TITLE;
        }

        /// <summary>
        /// GetDescription
        /// </summary>
        /// <returns>PageHeaderDescription</returns>
        public string GetDescription()
        {
            return $"Overzicht van cursussen uit week {WeekNumber} van {Year}";
        }

        /// <summary>
        /// InitializeYearsSelectList
        /// Initializes Years property in this class
        /// </summary>
        private void InitializeYearsSelectList()
        {
            // Last possible year to select in list is current year - startyear + YEAR_LEAD
            var numberOfYearsToAdd = (DateTime.Now.Year - START_YEAR) + YEAR_LEAD;
            Years = Enumerable.Range(START_YEAR, numberOfYearsToAdd)
            .Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString(),
            });
        }

        /// <summary>
        /// InitializeWeekNumbersSelectList
        /// Initializes WeekNumbers property in this class
        /// </summary>
        private void InitializeWeekNumbersSelectList()
        {
            // Fill with numbers, starting at 1, with count of 53. Result: (1-53)
            // We use 53 weeks since 52 != 365 / 7, but: 52,14285714285714. With leap years left out
            WeekNumbers = Enumerable.Range(FIRST_WEEKNUMBER, LAST_WEEKNUMBER)
            .Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });
        }
    }
}
