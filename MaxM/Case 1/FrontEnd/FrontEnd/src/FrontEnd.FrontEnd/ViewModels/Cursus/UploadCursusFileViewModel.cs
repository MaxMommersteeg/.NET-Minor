using FrontEnd.DataAnnotations;
using FrontEnd.ViewModels.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ViewModels.Cursus
{
    public class UploadCursusFileViewModel : IPageHeader
    {
        private const string TITLE = "Cursusbestand importeren";
        private const string DESCRIPTION = "Importeer hier uw cursusbestand";

        /// <summary>
        /// UploadCursusFileViewModel Constructor
        /// </summary>
        public UploadCursusFileViewModel()
        {
            UseDateRange = true;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddYears(1);
        }

        [Display(Name = "Gebruik periode", Description = "Vink uit voor importeren van volledige Cursusbestand")]
        public bool UseDateRange { get; set; }

        [Display(Name = "Begindatum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Einddatum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Dien een Cursusbestand in voordat u op 'Importeren' klikt.")]
        [CursusFile(ErrorMessage = "Ongeldig Cursusbestand")]
        [Display(Name = "Importeer Cursusbestand", Description = "Enkel tekstbestanden (.txt) zijn toegestaan")]
        public IFormFile CursusFile { get; set; }

        public CursusImportedFeedbackViewModel CursusImportedFeedbackViewModel { get; set; }
        public PageHeaderViewModel PageHeaderViewModel
        {
            get
            {
                return new PageHeaderViewModel(GetTitle(), GetDescription());
            }
        }

        /// <summary>
        /// GetTitle
        /// </summary>
        /// <returns>PageHeaderTitle</returns>
        public string GetTitle()
        {
            return TITLE;
        }

        /// <summary>
        /// PageHeaderDescription
        /// </summary>
        /// <returns>PageHeaderDescription</returns>
        public string GetDescription()
        {
            return DESCRIPTION;
        }
    }
}
