using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Text;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.IO;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.XMLSerialize
{
    [TestClass]
    public class RdwApkAgentTest
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ValidObjectCanBeSerializedAndDeserializedTest()
        {
            var verzoek = new ApkKeuringsverzoekRequestMessage();

            // dont set it wil give an error
            // verzoek.Xsd = "http://www.w3.org/2001/XMLSchema";
            // verzoek.Xsi = "http://www.w3.org/2001/XMLSchema-instance";

            verzoek.Keuringsverzoek = new Keuringsverzoek();
            verzoek.Keuringsverzoek.Apk =  "http://www.rdw.nl/apk";
            verzoek.Keuringsverzoek.CorrelatieId = "0038c17b-aa10- 4f93-8569- d184fdfc265b";
            verzoek.Keuringsverzoek.Keuringsdatum = "12-1-2016";
            verzoek.Keuringsverzoek.Xmlns = "http://www.rdw.nl/apk";

            verzoek.Keuringsverzoek.Voertuig = new Voertuig();
            verzoek.Keuringsverzoek.Voertuig.Kenteken = "BV-01-EG";
            verzoek.Keuringsverzoek.Voertuig.Kilometerstand = "12345";
            verzoek.Keuringsverzoek.Voertuig.Naam = "A. eigenaar";
            verzoek.Keuringsverzoek.Voertuig.Type = "personenauto";

            verzoek.Keuringsverzoek.Keuringsinstantie = new Keuringsinstantie();
            verzoek.Keuringsverzoek.Keuringsinstantie.Kvk = "3017 51123";
            verzoek.Keuringsverzoek.Keuringsinstantie.Naam = "De Groot";
            verzoek.Keuringsverzoek.Keuringsinstantie.Plaats = "De heurne";
            verzoek.Keuringsverzoek.Keuringsinstantie.Type = "garage";

            var serializer = new XmlSerializer(verzoek.GetType());
            
            using (var stream = new StringWriterWithEncoding(Encoding.UTF8))
            using (var xmlwriter = XmlWriter.Create(stream))
            {
                serializer.Serialize(xmlwriter, verzoek);
                var xml = stream.ToString();
                using (var reader = new StringReader(xml))
                {
                    var deserializer = new XmlSerializer(typeof(ApkKeuringsverzoekRequestMessage));
                    var obj = deserializer.Deserialize(reader);
                    Assert.IsInstanceOfType(obj, typeof(ApkKeuringsverzoekRequestMessage));
                       
                }   
            }
        }
    }
}
