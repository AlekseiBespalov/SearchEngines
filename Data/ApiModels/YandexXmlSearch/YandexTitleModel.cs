using System.Collections.Generic;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="title")]
    public class YandexTitleModel
    {
        [XmlElement(ElementName="hlword")]
        public List<string> Hlword { get; set; }

        [XmlText]
        public string Text {get; set;}
    }
}