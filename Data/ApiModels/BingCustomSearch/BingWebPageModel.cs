using System;

namespace SearchEngines.Data.ApiModels.BingCustomSearch
{
    public class BingWebPageModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public string Snippet { get; set; }
        public DateTime DateLastCrawled { get; set; }
        public string CachedPageUrl { get; set; }
    }
}
