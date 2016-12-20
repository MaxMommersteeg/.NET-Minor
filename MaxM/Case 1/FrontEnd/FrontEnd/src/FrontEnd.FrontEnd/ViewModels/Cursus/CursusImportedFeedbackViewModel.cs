using System.Collections.Generic;

namespace FrontEnd.ViewModels.Cursus
{
    public class CursusImportedFeedbackViewModel
    {
        public CursusImportedFeedbackViewModel(string title, int importedCount)
        {
            Title = title;
            ImportedCount = importedCount;
        }

        public string Title { get; private set; }
        public int ImportedCount { get; private set; }
    }
}
