using Microsoft.EntityFrameworkCore;
using SearchEngines.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.Repository
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        private readonly SearchEnginesDbContext _context;

        public SearchEngineRepository(SearchEnginesDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddSearchEngineToDbIfNotExistAsync(SearchEngineDto searchEngine)
        {
            SearchEngineDto searchEngineDto = _context.SearchEngines.FirstOrDefault(e => e.NameOfSearchEngine == searchEngine.NameOfSearchEngine);

            if(searchEngineDto == null)
            {
                await _context.AddAsync(searchEngine);
                await SaveChangesAsync();
                return searchEngine.Id;
            }
            else
            {
                return searchEngineDto.Id;
            }
        }

        public async Task<List<SearchEngineDto>> GetAllSearchEnginesAsync()
        {
            return await _context.SearchEngines.ToListAsync();
        }

        public async Task<SearchEngineDto> GetSearchEngineByIdAsync(int searchEngineId)
        {
            return await _context.SearchEngines.FindAsync(searchEngineId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
