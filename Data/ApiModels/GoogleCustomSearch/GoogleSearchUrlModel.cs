using Newtonsoft.Json;

namespace SearchEngines.Data.ApiModels.GoogleCustomSearch
{
    public class GoogleSearchUrlModel
    {
        [JsonProperty(PropertyName = "type")]
        public string UrlType { get; set; }

        public string Template { get; set; }
    }
}
