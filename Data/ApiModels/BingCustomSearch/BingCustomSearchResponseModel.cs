using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.ApiModels.BingCustomSearch
{
    public class BingCustomSearchResponseModel
    {
        [JsonProperty(PropertyName = "_type")]
        public string Type{ get; set; }

        public BingWebPagesModel WebPages { get; set; }
    }
}
