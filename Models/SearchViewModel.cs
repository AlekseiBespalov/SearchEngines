using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Models
{
    public class SearchViewModel
    {
        public RequestViewModel Request { get; set; }
        public List<SearchResultViewModel> SearchResults { get; set; }
    }
}
