using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="properties")]
    public class YandexPropertiesModel
    {
        [XmlElement(ElementName="_PassagesType")]
		public string PassagesType { get; set; }

        [XmlElement(ElementName="lang")]
		public string Lang { get; set; }
    }
}