using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks
{
    public class OnderhoudBeheerServiceExceptionAgentMock : IOnderhoudBeheerServiceAgent
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

            throw new Exception();
        }

        public Task<HttpOperationResponse<object>> UpdateOnderhoudsopdrachtWithHttpMessagesAsync(UpdateOnderhoudCommand updateOnderhoudCommand = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateOnderhoudsopdrachtTimesCalled++;

            throw new Exception();
        }
        public Task<HttpOperationResponse<object>> OnderhoudsopdrachtAfmeldenWithHttpMessagesAsync(OnderhoudAfmeldenCommand onderhoudAfmeldenCommand = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnderhoudsopdrachtAfmeldenTimesCalled++;

            throw new Exception();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
