using System.Collections.Generic;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="passage")]
    public class YandexPassageModel
    {
        [XmlElement(ElementName="hlword")]
        public List<string> Hlword { get; set; }
    }
}