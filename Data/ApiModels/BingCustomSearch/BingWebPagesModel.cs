namespace SearchEngines.Data.ApiModels.BingCustomSearch
{
    public class BingWebPagesModel
    {
        public string WebSearchUrl { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public BingWebPageModel[] Value { get; set; }        
    }
}
