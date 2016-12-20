using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Case2.MaRoWo.RDW.IntegrationService.Domain.Entities {
    public class ApkAanvraagLog
    {
        public long Id { get; set; }

        public string CorrelationId { get; set; }

        public string RequestMessage { get; set; }

        public string ResponseMessage { get; set; }
    }
}
