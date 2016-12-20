using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;
using Minor.Dag21.CASServiceClient.Agents;
using Minor.Dag21.CASServiceClient.Agents.Models;
using System.Net;
using Moq;
using System.Net.Http;

namespace Minor.Dag21.CAS.FrontEnd.MVC.Test.Mocks
{
    public class MockAgent : ICASService
    {
        public int NumberOfTimesAddCalled { get; private set; }
        public List<CursusInstantie> LijstCursusAddToevoeging { get; set; }
        public int NumberOfTimesGetByWeekCalled { get; private set; }
        public List<string> LijstGetByWeekInput { get; private set; }
        public int NumberOfTimesAddCursistCalled { get; internal set; }
        public List<Cursist> LijstCursusAddCursistToevoeging { get; internal set; }

        public MockAgent()
        {
            LijstCursusAddToevoeging = new List<CursusInstantie>();
            LijstCursusAddCursistToevoeging = new List<Cursist>();

            LijstGetByWeekInput = new List<string>();
        }
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

        public JsonSerializerSettings SerializationSettings
        {
            get
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

        public int NumberOfTimesIndexCursistCalled { get; private set; }
        public int NumberOfTimesIndexCursusCalled { get; internal set; }
        public int NumberOfTimesGetByIDCalled { get; private set; }
        public List<int> LijstGetByIDCursusToevoeging { get; private set; }

        public Task<HttpOperationResponse<object>> GetAllWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesIndexCursusCalled++;
            return null;
        }

        public Task<HttpOperationResponse<object>> UpdateWithHttpMessagesAsync(CursusInstantie value = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        
        public Task<HttpOperationResponse<object>> PostWithHttpMessagesAsync(CursusInstantie value = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesAddCalled++;
            LijstCursusAddToevoeging.Add(value);
            var _result = new HttpOperationResponse<object>();
            _result.Response = new HttpResponseMessage(HttpStatusCode.OK);
            return Task.FromResult(_result);

        }

        public Task<HttpOperationResponse<object>> GetByIDWithHttpMessagesAsync(int id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesGetByIDCalled++;
            LijstGetByIDCursusToevoeging.Add(id);
            return null;
        }

        public Task<HttpOperationResponse<object>> DeleteWithHttpMessagesAsync(int id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }




        public Task<HttpOperationResponse<object>> CursistGetAllWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesIndexCursistCalled++;
            return null;
        }

        public Task<HttpOperationResponse<object>> UpdateCursistWithHttpMessagesAsync(Cursist value = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PostCursistWithHttpMessagesAsync(Cursist value = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesAddCursistCalled++;
            LijstCursusAddCursistToevoeging.Add(value);
            return null;
        }

        public Task<HttpOperationResponse<object>> GetByIDCursistWithHttpMessagesAsync(int id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetByWeekWithHttpMessagesAsync(string datum, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            NumberOfTimesGetByWeekCalled++;
            LijstGetByWeekInput.Add(datum);
            return null;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetCursistenByInschrijvingWithHttpMessagesAsync(int cursusId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
