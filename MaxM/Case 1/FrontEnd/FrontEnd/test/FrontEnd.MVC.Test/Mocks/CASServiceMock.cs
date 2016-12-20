using FrontEnd.Agents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;
using FrontEnd.Agents.Models;
using System.Net.Http;

namespace FrontEnd.MVC.Test.Mocks
{
    public class CASServiceMock : ICASService
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

        public Task<HttpOperationResponse<object>> ApiV1CursusByCursuscodeByYearByMonthByDayGetWithHttpMessagesAsync(string cursuscode, int year, int month, int day, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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

        public Task<HttpOperationResponse<object>> ApiV1CursusByYearByWeeknumberGetWithHttpMessagesAsync(int weeknumber, int year, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            TimesCalled++;

            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");

            // Create Result
            var _result = new HttpOperationResponse<object>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            _result.Body = new List<Cursus>();

            return Task.FromResult(_result);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PostWithHttpMessagesAsync(Cursus cursus = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            TimesCalled++;
            throw new NotImplementedException();
        }
    }
}
