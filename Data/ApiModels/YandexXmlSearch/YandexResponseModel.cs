using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
	[XmlRoot(ElementName="response")]
    public class YandexResponseModel
    {
		[XmlElement(ElementName="reqid")]
		public string ReqId { get; set; }

		[XmlElement(ElementName="found")]
		public List<YandexFoundModel> Found { get; set; }

		[XmlElement(ElementName="found-human")]
		public string FoundHuman { get; set; }

		[XmlElement(ElementName="results")]
		public YandexResultsModel Results { get; set; }

		[XmlAttribute(AttributeName="date")]
		public string Date { get; set; }
    }
}
