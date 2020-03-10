using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [Serializable, XmlRoot("yandexsearch")]
    public class YandexSearchResultModel
    {
        [XmlElement(ElementName="request")]
		public YandexRequestModel Request { get; set; }

        [XmlElement(ElementName="response")]
		public YandexResponseModel Response { get; set; }

        [XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
    }
}
