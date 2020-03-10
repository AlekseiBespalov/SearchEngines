using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
    [XmlRoot(ElementName="groupby")]
    public class YandexGroupByModel
    {
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