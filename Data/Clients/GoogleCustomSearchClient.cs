using Flurl.Http;
using Newtonsoft.Json;
using SearchEngines.Data.ApiModels.GoogleCustomSearch;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Simple client implementation for 
/// Google custom search REST API
/// https://developers.google.com/custom-search/v1/
/// For example:
/// https://www.googleapis.com/customsearch/v1?key=AIzaSyDLn0aXSClF_n2QLbsHSCjh_RtNTgdIGCY&cx=014399301842138697111:zmkipl1bi9h&q=search+engine
/// </summary>
namespace SearchEngines.Data.Clients
{
    public class GoogleCustomSearchClient : ISearchClient<GoogleSearchResultModel>
    {
        private readonly string _apiUrl = "https://www.googleapis.com/customsearch/v1";
        private readonly string _apiKey = "AIzaSyDLn0aXSClF_n2QLbsHSCjh_RtNTgdIGCY";
        private readonly string _customSearchEngineId = "014399301842138697111:zmkipl1bi9h";

        public async Task<GoogleSearchResultModel> SearchByPhrase(string phrase)
        {
            if (phrase != null)
            {
                string phraseForSearchUrl = phrase.Replace(" ", "+");
                //Implementation of query URL through StringBuilder
                //_apiUrl + "?key=" + _apiKey + "&cx=" + _customSearchEngineId + "&q=" + phraseForSearch;

                StringBuilder searchUrl = new StringBuilder();
                searchUrl.Append(_apiUrl);
                searchUrl.Append("?key=");
                searchUrl.Append(_apiKey);
                searchUrl.Append("&cx=");
                searchUrl.Append(_customSearchEngineId);
                searchUrl.Append("&q=");
                searchUrl.Append(phraseForSearchUrl);
                
                dynamic googleCustomSearchResultJson = await searchUrl.ToString().GetJsonAsync();
                string serializedJson = JsonConvert.SerializeObject(googleCustomSearchResultJson, Formatting.None,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var searchResult = JsonConvert.DeserializeObject<GoogleSearchResultModel>(serializedJson);

                return searchResult;
            }
            else
            {
                return new GoogleSearchResultModel();
            }
        }
    }
}
