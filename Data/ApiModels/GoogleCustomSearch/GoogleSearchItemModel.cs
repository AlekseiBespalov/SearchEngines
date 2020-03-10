using Newtonsoft.Json;

public class GoogleSearchItemModel
{
    [JsonProperty(PropertyName = "kind")]
    public string KindOfResult { get; set; }

    public string Title { get; set; }

    public string HtmlTitle { get; set; }

    public string Link { get; set; }

    public string DisplayLink { get; set; }

    public string Snippet { get; set; }

    public string HtmlSnippet { get; set; }

    public string CacheId { get; set; }

    public string FormattedUrl { get; set; }

    public string HtmlFormattedUrl { get; set; }
}
