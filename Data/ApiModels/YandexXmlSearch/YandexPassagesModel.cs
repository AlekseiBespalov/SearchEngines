using System.Collections.Generic;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="passages")]
    public class YandexPassagesModel
    {
        [XmlElement(ElementName="passage")]
		public List<YandexPassageModel> Passage { get; set; }
    }
}