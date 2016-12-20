using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.RDW.IntegrationService.Facade.ErrorModel
{
    public class BadRequest
    {
        public string Message { get; set; }
        public IEnumerable<string> InvalidProperties {get;set;}
    }
}
