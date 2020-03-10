using System.Xml.Serialization;

namespace SearchEngines.Data.ApiModels.YandexXmlSearch
{
	[XmlRoot(ElementName="doc")]
    public class YandexDocModel
    {
		[XmlElement(ElementName="relevance")]
		public string Relevance { get; set; }

		[XmlElement(ElementName="url")]
		public string Url { get; set; }

		[XmlElement(ElementName="domain")]
		public string Domain { get; set; }

		[XmlElement(ElementName="title")]
		public YandexTitleModel Title { get; set; }

		[XmlElement(ElementName="modtime")]
		public string ModTime { get; set; }

		[XmlElement(ElementName="size")]
		public string Size { get; set; }

		[XmlElement(ElementName="charset")]
		public string Charset { get; set; }

		[XmlElement(ElementName="passages")]
		public YandexPassagesModel Passages { get; set; }

		[XmlElement(ElementName="properties")]
		public YandexPropertiesModel Properties { get; set; }

		[XmlElement(ElementName="mime-type")]
		public string MimeType { get; set; }

		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
    }
}