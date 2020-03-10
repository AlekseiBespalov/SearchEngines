using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Models
{
    public class SearchEngineViewModel
    {
        public int SearchEngineId { get; set; }
        public string NameOfSearchEngine { get; set; } = "Unknown";
    }
}
