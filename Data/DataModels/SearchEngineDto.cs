using System.Collections.Generic;

namespace SearchEngines.Data.DataModels
{
    public class SearchEngineDto
    {
        public int Id { get; set; }
        public string NameOfSearchEngine { get; set; } = "Unknown";
        public ICollection<SearchResultDto> SearchResults { get; set; }
    }
}
