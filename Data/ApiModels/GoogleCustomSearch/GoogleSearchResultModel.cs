using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.ApiModels.GoogleCustomSearch
{
    /// <summary>
    /// Google custom search API described not completely
    /// </summary>
    public class GoogleSearchResultModel
    {
        [JsonProperty(PropertyName = "kind")]
        public string KindOfSearch { get; set; }

        public GoogleSearchUrlModel Url { get; set; }

        public GoogleSearchQueriesModel Queries { get; set; }

        public GoogleSearchContextModel Context { get; set; }

        public GoogleSearchInformationModel SearchInformation { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<GoogleSearchItemModel> SearchItems { get; set; }
    }
}