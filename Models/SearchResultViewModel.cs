using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Models
{
    public class SearchResultViewModel
    {
        public string ResultName { get; set; }
        public string ResultUrl { get; set; }
        public SearchEngine SearchEngine { get; set; }
    }
}
