using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents
{
    public class RdwApkAgent : IRdwApkAgent
    {
        private readonly string _rdwRequestUrl;

        /// <summary>
        /// RdwApkAgent Constructor
        /// </summary>
        public RdwApkAgent(string rdwRequestUrl)
        {
            _rdwRequestUrl = rdwRequestUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apkRequest"></param>
        /// <returns></returns>
        public string SendApkKeuringsVerzoek(string xml)
        {
            using (var client = new HttpClient())
            {
                HttpContent requestContent = new StringContent(xml);
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                var result = client.PostAsync(_rdwRequestUrl, requestContent).Result;

                return result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
