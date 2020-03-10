using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Data.Clients
{
    interface ISearchClient<T> where T : class
    {
        Task<T> SearchByPhrase(string phrase);
    }
}
