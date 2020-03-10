using Newtonsoft.Json;
using SearchEngines.Data.ApiModels.BingCustomSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngines.Data.Clients
{
    public class BingCustomSearchClient : ISearchClient<BingCustomSearchResponseModel>
    {
        private readonly string _apiUrl = "https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search";
        private readonly string _apiKey = "2bba6d4a1b6f4f42bb70e1bba9a79483";
        private readonly string _customConfigId = "8748f975-ae09-416f-9cb0-767baa4d4bd0";
        private readonly string _market = "en-US";
        private readonly string _searchLang = "EN";

        public async Task<BingCustomSearchResponseModel> SearchByPhrase(string phrase)
        {
            if (phrase != null)
            {
                string phraseForSearchUrl = phrase.Replace(" ", "%");

                //"https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search?" + "q=" + searchTerm + "&" + "customconfig=" + customConfigId;
                StringBuilder searchUrl = new StringBuilder();
                searchUrl.Append(_apiUrl);
                searchUrl.Append("?q=");
                searchUrl.Append(phraseForSearchUrl);
                searchUrl.Append("&customconfig=");
                searchUrl.Append(_customConfigId);
                searchUrl.Append("&mkt=");
                searchUrl.Append(_market);
                searchUrl.Append("&setLang=");
                searchUrl.Append(_searchLang);

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);

                var httpResponseMessage = client.GetAsync(searchUrl.ToString()).Result;
                var responseContext = httpResponseMessage.Content.ReadAsStringAsync().Result;
                BingCustomSearchResponseModel searchResult = JsonConvert.DeserializeObject<BingCustomSearchResponseModel>(responseContext);

                return searchResult;
            }
            else
            {
                return new BingCustomSearchResponseModel();
            }
        }
    }
}
