using System.ComponentModel.DataAnnotations;

namespace FrontEnd.MVC.Test.Mocks
{
    public class DummyViewModelMock
    {
        [Display(Name = "Test Property With Description", Description = "This is the description")]
        public string TestPropertyWithDescription { get; set; }
    }
}
