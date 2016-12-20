using System.Xml.Serialization;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated
{

    [XmlRoot(ElementName = "apkKeuringsverzoekRequestMessage")]
    public class ApkKeuringsverzoekRequestMessage
    {
        [XmlElement(ElementName = "keuringsverzoek", Namespace = "http://www.rdw.nl")]
        public Keuringsverzoek Keuringsverzoek { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }

    [XmlRoot(ElementName = "voertuig", Namespace = "http://www.rdw.nl")]
    public class Voertuig
    {
        [XmlElement(ElementName = "kenteken", Namespace = "http://www.rdw.nl")]
        public string Kenteken { get; set; }
        [XmlElement(ElementName = "kilometerstand", Namespace = "http://www.rdw.nl")]
        public string Kilometerstand { get; set; }
        [XmlElement(ElementName = "naam", Namespace = "http://www.rdw.nl")]
        public string Naam { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "keuringsinstantie", Namespace = "http://www.rdw.nl/apk")]
    public class Keuringsinstantie
    {
        [XmlElement(ElementName = "naam", Namespace = "http://www.rdw.nl/apk")]
        public string Naam { get; set; }
        [XmlElement(ElementName = "plaats", Namespace = "http://www.rdw.nl/apk")]
        public string Plaats { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "kvk")]
        public string Kvk { get; set; }
    }

    [XmlRoot(ElementName = "keuringsverzoek", Namespace = "http://www.rdw.nl")]
    public class Keuringsverzoek
    {
        [XmlElement(ElementName = "voertuig", Namespace = "http://www.rdw.nl")]
        public Voertuig Voertuig { get; set; }

        [XmlElement(ElementName = "keuringsdatum", Namespace = "http://www.rdw.nl/apk")]
        public string Keuringsdatum { get; set; }

        [XmlElement(ElementName = "keuringsinstantie", Namespace = "http://www.rdw.nl/apk")]
        public Keuringsinstantie Keuringsinstantie { get; set; }

        [XmlAttribute(AttributeName = "correlatieId")]
        public string CorrelatieId { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "apk", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Apk { get; set; }
    }



}
