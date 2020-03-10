using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="group")]
    public class YandexGroupModel
    {
        [XmlElement(ElementName="doccount")]
		public string DocCount { get; set; }

        [XmlElement(ElementName="relevance")]
		public string Relevance { get; set; }

        [XmlElement(ElementName="doc")]
		public YandexDocModel Doc { get; set; }
    }
}