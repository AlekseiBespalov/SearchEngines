using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="page")]
    public class YandexPageModel
    {
        [XmlAttribute(AttributeName="first")]
		public string First { get; set; }

        [XmlAttribute(AttributeName="last")]
		public string Last { get; set; }

        [XmlText]
		public string Text { get; set; }
    }
}