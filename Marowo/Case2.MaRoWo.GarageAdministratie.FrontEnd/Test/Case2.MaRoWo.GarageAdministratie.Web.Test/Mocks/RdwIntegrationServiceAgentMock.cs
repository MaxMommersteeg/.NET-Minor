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
    public class RdwIntegrationServiceAgentMock : IRdwIntegrationServiceAgent
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

            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");

            // Create Result
            var _result = new HttpOperationResponse<object>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            _result.Body = false;

            return Task.FromResult(_result);
        }
    }
}
