using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="sortby")]
    public class YandexSortbyModel
    {
        [XmlAttribute(AttributeName="order")]
		public string Order { get; set; }

        [XmlAttribute(AttributeName="priority")]
		public string Priority { get; set; }

        [XmlText]
		public string Text { get; set; }
    }
}