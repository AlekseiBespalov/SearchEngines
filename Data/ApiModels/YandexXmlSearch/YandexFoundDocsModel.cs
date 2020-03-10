using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="found-docs")]
    public class YandexFoundDocsModel
    {
        [XmlAttribute(AttributeName="priority")]
        public string Priority { get; set; }

        [XmlText]
		public string Text { get; set; }
    }
}