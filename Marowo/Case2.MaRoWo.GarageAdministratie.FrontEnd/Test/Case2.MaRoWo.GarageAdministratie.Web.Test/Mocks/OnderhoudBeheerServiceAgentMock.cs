using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks
{
    public class OnderhoudBeheerServiceAgentMock : IOnderhoudBeheerServiceAgent
    {
        public int AddOnderhoudsopdrachtTimesCalled { get; set; }
        public int UpdateOnderhoudsopdrachtTimesCalled { get; set; }
        public int OnderhoudsopdrachtAfmeldenTimesCalled { get; set; }

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

        public Task<HttpOperationResponse<object>> AddOnderhoudsopdrachtWithHttpMessagesAsync(CreateOnderhoudCommand onderhoudCommand = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddOnderhoudsopdrachtTimesCalled++;

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
        public Task<HttpOperationResponse<object>> UpdateOnderhoudsopdrachtWithHttpMessagesAsync(UpdateOnderhoudCommand updateOnderhoudCommand = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateOnderhoudsopdrachtTimesCalled++;

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
    
        public Task<HttpOperationResponse<object>> OnderhoudsopdrachtAfmeldenWithHttpMessagesAsync(OnderhoudAfmeldenCommand onderhoudAfmeldenCommand = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnderhoudsopdrachtAfmeldenTimesCalled++;

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
