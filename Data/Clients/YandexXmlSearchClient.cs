using Flurl.Http;
using Flurl.Http.Xml;
using SearchEngines.Data.ApiModels.YandexXmlSearch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// URL for requests:
/// https://yandex.com/search/xml?l10n=en&user=bespaloww2013&key=03.183438101:42db3c923b100c6edb3bc232094abe60
/// or
/// https://yandex.com/search/xml?user=bespaloww2013&key=03.183438101:42db3c923b100c6edb3bc232094abe60&query=search+engine&l10n=en&sortby=tm.order%3Dascending&filter=strict
/// </summary>
namespace SearchEngines.Data.Clients
{
    public class YandexXmlSearchClient : ISearchClient<YandexSearchResultModel>
    {
        private readonly string _apiUrl = "https://yandex.com/search/xml";
        private readonly string _user = "bespaloww2013";
        private readonly string _apiKey = "03.183438101:42db3c923b100c6edb3bc232094abe60";

        public async Task<YandexSearchResultModel> SearchByPhrase(string phrase)
        {
            if (phrase != null)
            {
                string phraseForSearchUrl = phrase.Replace(" ", "+");

                //_apiUrl + "?user=" + _user + "&key=" + _apiKey + "&query=" + phraseForSearchUrl
                StringBuilder searchUrl = new StringBuilder();
                searchUrl.Append(_apiUrl);
                searchUrl.Append("?user=");
                searchUrl.Append(_user);
                searchUrl.Append("&key=");
                searchUrl.Append(_apiKey);
                searchUrl.Append("&query=");
                searchUrl.Append(phraseForSearchUrl);

                var yandexXmlSearchResult = await searchUrl.ToString().GetXDocumentAsync();
                var xmlStringYandex = yandexXmlSearchResult.ToString();
                //OK

                XmlSerializer serializer = new XmlSerializer(typeof(YandexSearchResultModel));
                YandexSearchResultModel searchResult = new YandexSearchResultModel();

                using (TextReader reader = new StringReader(xmlStringYandex))
                {
                    searchResult = (YandexSearchResultModel)serializer.Deserialize(reader);
                }

                return searchResult;
            }
            else
            {
                return new YandexSearchResultModel();
            }
        }
    }
}
