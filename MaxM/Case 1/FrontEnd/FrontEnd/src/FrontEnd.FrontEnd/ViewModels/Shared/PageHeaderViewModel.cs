namespace FrontEnd.ViewModels.Shared
{
    public class PageHeaderViewModel
    {
        public PageHeaderViewModel(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
