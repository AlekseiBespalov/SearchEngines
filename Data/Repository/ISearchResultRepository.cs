using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngines.Data.DataModels;

namespace SearchEngines.Data.Repository
{
    public interface ISearchResultRepository
    {
        Task AddResultsToDbAsync(IList<SearchResultDto> searchResults);
        Task<List<SearchResultDto>> GetAllSearchResultsAsync();

        Task AddResultToDbAsync(SearchResultDto searchResult);
        Task <SearchResultDto> GetSearchResultByIdAsync(int resultId);
        List<SearchResultDto> GetResultsByPhrase(string phraseForSearch);
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
