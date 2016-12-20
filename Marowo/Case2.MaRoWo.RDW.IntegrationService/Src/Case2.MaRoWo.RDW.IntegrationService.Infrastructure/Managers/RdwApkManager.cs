using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents;
using System;
using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories;
using System.Xml;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.IO;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Minor.RoWe.Common.Interfaces;
using Minor.Case2.Events.RDWIntegration;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers
{
    public class RdwApkManager : IRdwApkManager, IDisposable
    {
        private readonly IRdwApkAgent _rdwApkAgent;
        private readonly IKeuringsVerzoekConverter _keuringsVerzoekConverter;
        private readonly IRepository<ApkAanvraagLog, long> _apkAanvraagLogRepository;
        private readonly string _keuringsVerzoekXmlns;
        private readonly string _keuringVerzoekApk;
        private readonly IEventPublisher _publisher;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdwApkAgent"></param>
        /// <param name="apkAanvraagLogRepositor"></param>
        public RdwApkManager(
            IRdwApkAgent rdwApkAgent,
            IKeuringsVerzoekConverter keuringsVerzoekConverter,
            IRepository<ApkAanvraagLog, long> apkAanvraagLogRepository,
            string keuringsverzoekXmlns,
            string keuringsverzoekApk, IEventPublisher publisher)
        {
            _rdwApkAgent = rdwApkAgent;
            _keuringsVerzoekConverter = keuringsVerzoekConverter;
            _apkAanvraagLogRepository = apkAanvraagLogRepository;
            _keuringsVerzoekXmlns = keuringsverzoekXmlns;
            _keuringVerzoekApk = keuringsverzoekApk;
            _publisher = publisher;
        }

        /// <summary>
        /// HandleApkKeuringsVerzoek
        /// </summary>
        /// <param name="apkRequestCommand"></param>
        /// <returns></returns>
        public KeuringsVerzoekAntwoord HandleApkKeuringsVerzoek(ApkKeuringsVerzoekCommand apkCommand)
        {
            if (apkCommand == null)
            {
                throw new ArgumentNullException("ApkKeuringsVerzoekCommand should not be null");
            }

            var apkKeuringsVerzoek = CreateRequestFromCommand(apkCommand);

            string responseMessage = LogAndSendRequest(apkKeuringsVerzoek);
            var respone = HandleRdwResponse(responseMessage);

            PublishApkEvent(respone, apkCommand);
            return respone;
        }

        private void PublishApkEvent(KeuringsVerzoekAntwoord respone, ApkKeuringsVerzoekCommand apkCommand)
        {
            var apkCreated = new ApkAfgemeldEvent();

            apkCreated.CorrelationID = Guid.NewGuid();
            apkCreated.RoutingKey = "Minor.Case2.MaRoWe.RWD.Integration.ApkAfgemeld";
            apkCreated.TimeStamp = DateTime.UtcNow;

            apkCreated.Kenteken = apkCommand.Kenteken;
            apkCreated.OnderhoudsBeurtId = apkCommand.OnderhoudsBeurtId;
            apkCreated.HasSteekProef = respone.IsSteekProef;
            if (respone.IsSteekProef)
            {
                apkCreated.SteekProefDatum = respone.SteepkProefDate.Value;
            }
            _publisher.Publish(apkCreated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apkCommand"></param>
        /// <returns></returns>
        public ApkKeuringsverzoekRequestMessage CreateRequestFromCommand(ApkKeuringsVerzoekCommand apkCommand)
        {
            var verzoek = new ApkKeuringsverzoekRequestMessage();

            verzoek.Keuringsverzoek = new Keuringsverzoek();
            verzoek.Keuringsverzoek.Apk = _keuringVerzoekApk;
            verzoek.Keuringsverzoek.CorrelatieId = Guid.NewGuid().ToString();
            verzoek.Keuringsverzoek.Keuringsdatum = apkCommand.KeuringsDatum.ToString("d-M-yyyy");
            verzoek.Keuringsverzoek.Xmlns = _keuringsVerzoekXmlns;

            verzoek.Keuringsverzoek.Voertuig = new Voertuig();
            verzoek.Keuringsverzoek.Voertuig.Kenteken = apkCommand.Kenteken;
            verzoek.Keuringsverzoek.Voertuig.Kilometerstand = apkCommand.Kilometerstand.ToString();
            verzoek.Keuringsverzoek.Voertuig.Naam = apkCommand.EigenaarNaam;
            verzoek.Keuringsverzoek.Voertuig.Type = apkCommand.VoertuigType;

            verzoek.Keuringsverzoek.Keuringsinstantie = new Keuringsinstantie();
            verzoek.Keuringsverzoek.Keuringsinstantie.Kvk = apkCommand.KeuringsinstantieKvkNummer;
            verzoek.Keuringsverzoek.Keuringsinstantie.Naam = apkCommand.Bedrijfsnaam;
            verzoek.Keuringsverzoek.Keuringsinstantie.Plaats = apkCommand.BedrijfPlaats;
            verzoek.Keuringsverzoek.Keuringsinstantie.Type = apkCommand.KeuringsinstantieType;
            return verzoek;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string ConvertRequestToXML(ApkKeuringsverzoekRequestMessage request)
        {
            var serializer = new XmlSerializer(typeof(ApkKeuringsverzoekRequestMessage));
            using (var stream = new StringWriterWithEncoding(Encoding.UTF8))
            using (var xmlwriter = XmlWriter.Create(stream))
            {
                serializer.Serialize(xmlwriter, request);
                return stream.ToString();
            }
        }

        private string LogAndSendRequest(ApkKeuringsverzoekRequestMessage apkKeuringsVerzoek)
        {
            var requestMessage = ConvertRequestToXML(apkKeuringsVerzoek);

            var requestLog = new ApkAanvraagLog();
            // log request
            requestLog.CorrelationId = apkKeuringsVerzoek.Keuringsverzoek.CorrelatieId;
            requestLog.RequestMessage = requestMessage;

            _apkAanvraagLogRepository.Insert(requestLog);

            // make request
            var responseMessage = _rdwApkAgent.SendApkKeuringsVerzoek(requestMessage);

            // log respone
            requestLog.ResponseMessage = responseMessage;
            _apkAanvraagLogRepository.Update(requestLog);
            return responseMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="requestLog"></param>
        /// <returns></returns>
        private KeuringsVerzoekAntwoord HandleRdwResponse(string responseMessage)
        {
            // Store Log response using _apkAanvraagLogRepository
            using (var reader = new StringReader(responseMessage))
            {
                var deserializer = new XmlSerializer(typeof(ApkKeuringsverzoekResponseMessage));
                var responseObject = deserializer.Deserialize(reader) as ApkKeuringsverzoekResponseMessage;
                if (responseObject == null)
                {
                    throw new InvalidDataException("Invalid XML stream received, could not cast XML to ApkKeuringsverzoekResponseMessage");
                }
                var verzoekAntwoord = _keuringsVerzoekConverter.ToKeuringsVerzoekAntwoord(responseObject.Keuringsregistratie);
                return verzoekAntwoord;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _apkAanvraagLogRepository?.Dispose();
            _publisher?.Dispose();
        }
    }
}
