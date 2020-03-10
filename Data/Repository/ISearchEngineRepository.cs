using SearchEngines.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.Repository
{
    public interface ISearchEngineRepository
    {
        Task<int> AddSearchEngineToDbIfNotExistAsync(SearchEngineDto searchEngine);
        Task<List<SearchEngineDto>> GetAllSearchEnginesAsync();

        Task <SearchEngineDto> GetSearchEngineByIdAsync(int searchEngineId);
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
