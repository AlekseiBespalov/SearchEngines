using Microsoft.EntityFrameworkCore;
using SearchEngines.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.Repository
{
    public class SearchResultRepository : ISearchResultRepository
    {
        private readonly SearchEnginesDbContext _context;

        public SearchResultRepository(SearchEnginesDbContext context)
        {
            _context = context;
        }

        public async Task AddResultsToDbAsync(IList<SearchResultDto> searchResults)
        {
            await _context.AddRangeAsync(searchResults);
            await SaveChangesAsync();
        }

        public async Task<List<SearchResultDto>> GetAllSearchResultsAsync()
        {
            return await _context.SearchResults.ToListAsync();
        }

        public List<SearchResultDto> GetResultsByPhrase(string phraseForSearch)
        {
            List<SearchResultDto> results = new List<SearchResultDto>();
            if(phraseForSearch != null)
            {
                var dbResults = _context.SearchResults.Where(result => 
                    result.ResultName.Contains(phraseForSearch)).Include(e => e.SearchEngine);

                results.AddRange(dbResults);
            }
            return results;
        }

        public async Task AddResultToDbAsync(SearchResultDto searchResult)
        {
            await _context.AddAsync(searchResult);
            await SaveChangesAsync();
        }

        public async Task<SearchResultDto> GetSearchResultByIdAsync(int resultId)
        {
            return await _context.SearchResults.FindAsync(resultId);
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
