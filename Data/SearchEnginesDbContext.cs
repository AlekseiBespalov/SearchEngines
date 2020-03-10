using Microsoft.EntityFrameworkCore;
using SearchEngines.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data
{
    public class SearchEnginesDbContext : DbContext
    {
        public virtual DbSet<SearchEngineDto> SearchEngines { get; set; }
        public virtual DbSet<SearchResultDto> SearchResults { get; set; }

        public SearchEnginesDbContext(DbContextOptions<SearchEnginesDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchEngineDto>()
                .HasMany(e => e.SearchResults)
                .WithOne(s => s.SearchEngine);
        }
    }
}
