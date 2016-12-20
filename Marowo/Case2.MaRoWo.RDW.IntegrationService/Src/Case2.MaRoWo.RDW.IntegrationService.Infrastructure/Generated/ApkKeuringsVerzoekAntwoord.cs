using System.Xml.Serialization;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated
{

    [XmlRoot(ElementName = "steekproef", Namespace = "http://www.rdw.nl/apk")]
    public class Steekproef
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "keuringsregistratie", Namespace = "http://www.rdw.nl")]
    public class Keuringsregistratie
    {
        [XmlElement(ElementName = "kenteken", Namespace = "http://www.rdw.nl")]
        public string Kenteken { get; set; }
        [XmlElement(ElementName = "keuringsdatum", Namespace = "http://www.rdw.nl/apk")]
        public string Keuringsdatum { get; set; }
        [XmlElement(ElementName = "steekproef", Namespace = "http://www.rdw.nl/apk")]
        public Steekproef Steekproef { get; set; }
        [XmlAttribute(AttributeName = "correlatieId")]
        public string CorrelatieId { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "apk", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Apk { get; set; }
    }

    [XmlRoot(ElementName = "apkKeuringsverzoekResponseMessage")]
    public class ApkKeuringsverzoekResponseMessage
    {
        [XmlElement(ElementName = "keuringsregistratie", Namespace = "http://www.rdw.nl")]
        public Keuringsregistratie Keuringsregistratie { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }

}
