using Newtonsoft.Json;

public class GoogleSearchRequestModel
{
    [JsonProperty(PropertyName = "title")]
    public string RequestTitle { get; set; }

    public string TotalResults { get; set; }

    public string SearchTerms { get; set; }

    public int Count { get; set; }

    public int StartIndex { get; set; }

    public string InputEncoding { get; set; }

    public string OutputEncoding { get; set; }

    public string Safe { get; set; }

    [JsonProperty(PropertyName = "cx")]
    public string SearchEngineIdentifier { get; set; }
}
