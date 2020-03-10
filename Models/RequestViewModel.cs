using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Models
{
    public class RequestViewModel
    {
        public string SearchString { get; set; }
        public SearchEngine SearchEngine { get; set; }
    }
}
