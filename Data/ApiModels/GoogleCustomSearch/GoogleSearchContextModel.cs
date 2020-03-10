using Newtonsoft.Json;

public class GoogleSearchContextModel
{
    [JsonProperty(PropertyName = "title")]
    public string ContextName { get; set; }
}
