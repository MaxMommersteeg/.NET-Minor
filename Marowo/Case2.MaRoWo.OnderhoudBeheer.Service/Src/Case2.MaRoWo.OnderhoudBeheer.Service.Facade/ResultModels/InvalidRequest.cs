using System.Collections.Generic;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade.ResultModels {
    public class InvalidRequest
    {
        public InvalidRequest()
        {

        }

        public InvalidRequest(string message, IEnumerable<string> invalidProperties)
        {
            Message = message;
            InvalidProperties = invalidProperties;
        }

        public string Message { get; set; }
        public IEnumerable<string> InvalidProperties { get; set; }
    }
}
