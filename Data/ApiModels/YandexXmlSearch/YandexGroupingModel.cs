using System.Collections.Generic;
using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
	[XmlRoot(ElementName="grouping")]
    public class YandexGroupingModel
    {
		[XmlElement(ElementName="found")]
		public List<YandexFoundModel> Found { get; set; }

		[XmlElement(ElementName="found-docs")]
		public List<YandexFoundDocsModel> FoundDocs { get; set; }

		[XmlElement(ElementName="found-docs-human")]
		public string FoundDocsHuman { get; set; }

		[XmlElement(ElementName="page")]
		public YandexPageModel Page { get; set; }

		[XmlElement(ElementName="group")]
		public List<YandexGroupModel> Group { get; set; }

		[XmlAttribute(AttributeName="attr")]
		public string Attr { get; set; }

		[XmlAttribute(AttributeName="mode")]
		public string Mode { get; set; }

		[XmlAttribute(AttributeName="groups-on-page")]
		public string GroupsOnPage { get; set; }

		[XmlAttribute(AttributeName="docs-in-group")]
		public string DocsInGroup { get; set; }

		[XmlAttribute(AttributeName="curcateg")]
		public string CurCateg { get; set; }
    }
}