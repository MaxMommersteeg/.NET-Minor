using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks
{
    public class RdwIntegrationServiceExceptionAgent : IRdwIntegrationServiceAgent
    {
        public int TimesCalled { get; set; }

        public Uri BaseUri
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public JsonSerializerSettings DeserializationSettings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public JsonSerializerSettings SerializationSettings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> MakeApkRequestWithHttpMessagesAsync(ApkKeuringsVerzoekCommand command = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            TimesCalled++;

            throw new Exception();
        }
    }
}
