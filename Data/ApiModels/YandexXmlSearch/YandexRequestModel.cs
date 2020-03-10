using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
	[XmlRoot(ElementName="request")]
    public class YandexRequestModel
    {
		[XmlElement(ElementName="query")]
		public string Query { get; set; }

		[XmlElement(ElementName="page")]
		public string Page { get; set; }

		[XmlElement(ElementName="sortby")]
		public YandexSortbyModel SortBy { get; set; }

		[XmlElement(ElementName="maxpassages")]
		public string MaxPassages { get; set; }

		[XmlElement(ElementName="groupings")]
		public YandexGroupingsModel Groupings { get; set; }
    }
}
