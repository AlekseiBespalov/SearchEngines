namespace SearchEngines.Data.DataModels
{
    public class SearchResultDto
    {
        public int Id { get; set; }

        public string ResultName { get; set; }

        public string ResultUrl { get; set; }

        public SearchEngineDto SearchEngine { get; set; }
    }
}
