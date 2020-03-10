using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="results")]
    public class YandexResultsModel
    {
        [XmlElement(ElementName="grouping")]
        public YandexGroupingModel Grouping { get; set; }
    }
}