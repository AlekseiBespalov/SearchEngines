using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="groupings")]
    public class YandexGroupingsModel
    {
        [XmlElement(ElementName="groupby")]
        public YandexGroupByModel Groupby { get; set; }
    }
}