using FrontEnd.ViewModels.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ViewModels.Cursus
{
    public class CursusViewModel : IPageHeader
    {
        /// <summary>
        /// CursusViewModel constructor
        /// </summary>
        public CursusViewModel()
        {

        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Aantal dagen")]
        public int DateCount { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Aantal cursisten")]
        public int CursistCount { get; set; }

        /// <summary>
        /// GetTitle
        /// </summary>
        /// <returns>PageHeaderTitle</returns>
        public string GetTitle()
        {
            return $"Cursus: {Title}";
        }

        /// <summary>
        /// GetDescription
        /// </summary>
        /// <returns>PageHeaderDescription</returns>
        public string GetDescription()
        {
            return string.Empty;
        }
    }
}
