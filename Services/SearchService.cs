using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SearchEngines.Data.ApiModels.BingCustomSearch;
using SearchEngines.Data.ApiModels.GoogleCustomSearch;
using SearchEngines.Data.ApiModels.YandexXmlSearch;
using SearchEngines.Data.Clients;
using SearchEngines.Data.DataModels;
using SearchEngines.Data.Repository;
using SearchEngines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Services
{
    public class SearchService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISearchResultRepository _searchResultRepository;
        private readonly ISearchEngineRepository _searchEngineRepository;

        private readonly IMapper _mapper;

        public SearchService(IServiceProvider serviceProvider, ISearchResultRepository searchResultRepository,
            ISearchEngineRepository searchEngineRepository, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _searchResultRepository = searchResultRepository;
            _searchEngineRepository = searchEngineRepository;
            _mapper = mapper;
        }

        public async Task<List<SearchResultViewModel>> SearchByPhraseInSearchEngine(string phraseForSearch, SearchEngine searchEngine)
        {
            List<SearchResultViewModel> searchResults = new List<SearchResultViewModel>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var googleCustomSearchClient = scope.ServiceProvider.GetRequiredService<ISearchClient<GoogleSearchResultModel>>();
                var bingCustomSearchClient = scope.ServiceProvider.GetRequiredService<ISearchClient<BingCustomSearchResponseModel>>();
                var yandexXmlSearchClient = scope.ServiceProvider.GetRequiredService<ISearchClient<YandexSearchResultModel>>();
                var searchResultRepository = scope.ServiceProvider.GetRequiredService<ISearchResultRepository>();
                var searchEngineRepository = scope.ServiceProvider.GetRequiredService<ISearchEngineRepository>();

                if(searchEngine == SearchEngine.Google)
                {
                    //Add search engine to database if not exist and get id of existed search engine
                    var googleDto = new SearchEngineDto { NameOfSearchEngine="Google" };
                    var searchEngineId = await searchEngineRepository.AddSearchEngineToDbIfNotExistAsync(googleDto);
                    googleDto = await searchEngineRepository.GetSearchEngineByIdAsync(searchEngineId);

                    //Create request to Google custom search api and convert to ViewModel for returning in controller
                    var googleSearchResult = await googleCustomSearchClient.SearchByPhrase(phraseForSearch);
                    var googleSearchResultViewModel = ConvertGoogleResultToViewModel(googleSearchResult);
                    searchResults = googleSearchResultViewModel;

                    //Convert result to Dto and add the first result to database
                    var googleSearchResultDto = ConvertGoogleResultToDto(googleSearchResult, googleDto);
                    await searchResultRepository.AddResultToDbAsync(googleSearchResultDto[0]);
                }

                if(searchEngine == SearchEngine.Bing)
                {
                    var bingDto = new SearchEngineDto { NameOfSearchEngine = "Bing" };
                    var searchEngineId = await searchEngineRepository.AddSearchEngineToDbIfNotExistAsync(bingDto);
                    bingDto = await searchEngineRepository.GetSearchEngineByIdAsync(searchEngineId);

                    var bingSearchResult = await bingCustomSearchClient.SearchByPhrase(phraseForSearch);
                    var bingSearchResultViewModel = ConvertBingResultToViewModel(bingSearchResult);
                    searchResults = bingSearchResultViewModel;

                    var bingSearchResultDto = ConvertBingResultToDto(bingSearchResult, bingDto);
                    await searchResultRepository.AddResultToDbAsync(bingSearchResultDto[0]);
                }

                if(searchEngine == SearchEngine.Yandex)
                {
                    var yandexDto = new SearchEngineDto { NameOfSearchEngine="Yandex" };
                    var searchEngineId = await searchEngineRepository.AddSearchEngineToDbIfNotExistAsync(yandexDto);
                    yandexDto = await searchEngineRepository.GetSearchEngineByIdAsync(searchEngineId);

                    YandexSearchResultModel yandexSearchResult = await yandexXmlSearchClient.SearchByPhrase(phraseForSearch);
                    var yandexSearchResultViewModel = ConvertYandexResultToViewModel(yandexSearchResult);
                    searchResults = yandexSearchResultViewModel;

                    var yandexSearchResultDto = ConvertYandexResultToDto(yandexSearchResult, yandexDto);
                    await searchResultRepository.AddResultToDbAsync(yandexSearchResultDto[0]);
                }
            }
            return searchResults;
        }

        public async Task<List<SearchResultViewModel>> SearchByPhraseInDb(string phraseForSearch)
        {
            List<SearchResultViewModel> searchResults = new List<SearchResultViewModel>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var searchResultRepository = scope.ServiceProvider.GetRequiredService<ISearchResultRepository>();
                var searchEngineRepository = scope.ServiceProvider.GetRequiredService<ISearchEngineRepository>(); 

                if(phraseForSearch != null)
                {
                    searchResults.AddRange(ConvertDtoToViewModel(searchResultRepository.GetResultsByPhrase(phraseForSearch)));
                }
            }

            return searchResults;
        }

        #region Mappings and converters
        private List<SearchResultViewModel> ConvertDtoToViewModel(List<SearchResultDto> dbSearchResults)
        {
            var searchResults = new List<SearchResultViewModel>();
            foreach(var result in dbSearchResults)
            {
                searchResults.Add(new SearchResultViewModel 
                {
                    ResultName = result.ResultName,
                    ResultUrl = result.ResultUrl,
                    SearchEngine = (SearchEngine)Enum.Parse(typeof(SearchEngine), result.SearchEngine.NameOfSearchEngine)
                });
            }

            return searchResults;
        }

        #region Google mappings
        private List<SearchResultDto> ConvertGoogleResultToDto(GoogleSearchResultModel googleResult, SearchEngineDto searchEngine)
        {
            var dtoSearchResults = new List<SearchResultDto>();
            try
            {
                foreach(var item in googleResult.SearchItems)
                {
                    dtoSearchResults.Add(new SearchResultDto
                    {
                        ResultName = item.Title,
                        ResultUrl = item.FormattedUrl,
                        SearchEngine = searchEngine
                    });
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Google search result to Dto - "+ $"{ex.Message}");
            }

            return dtoSearchResults;
        }

        private List<SearchResultViewModel> ConvertGoogleResultToViewModel(GoogleSearchResultModel googleResult)
        {
            var searchResults = new List<SearchResultViewModel>();
            try
            {
                foreach(var item in googleResult.SearchItems)
                {
                    searchResults.Add(new SearchResultViewModel 
                    {
                        ResultName = item.Title,
                        ResultUrl = item.FormattedUrl,
                        SearchEngine = SearchEngine.Google
                    });
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Google search result to ViewModel - "+ $"{ex.Message}");
            }

            return searchResults;
        }
        #endregion

        #region Bing mappings
        private List<SearchResultViewModel> ConvertBingResultToViewModel(BingCustomSearchResponseModel bingResult)
        {
            var searchResults = new List<SearchResultViewModel>();

            try
            {
                foreach(var page in bingResult.WebPages.Value)
                {
                    searchResults.Add(new SearchResultViewModel
                    {
                        ResultName = page.Name,
                        ResultUrl = page.Url,
                        SearchEngine = SearchEngine.Bing
                    });
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Bing search result to ViewModel - "+ $"{ex.Message}");
            }

            return searchResults;
        }

        private List<SearchResultDto> ConvertBingResultToDto(BingCustomSearchResponseModel bingResponse, SearchEngineDto searchEngine)
        {
            var dtoSearchResults = new List<SearchResultDto>();

            try
            {
                foreach(var item in bingResponse.WebPages.Value)
                {
                    dtoSearchResults.Add(new SearchResultDto
                    {
                        ResultName = item.Name,
                        ResultUrl = item.Url,
                        SearchEngine = searchEngine
                    });
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Bing search result to Dto - "+ $"{ex.Message}");
            }

            return dtoSearchResults;
        }
        #endregion

        #region Yandex mappings
        private List<SearchResultViewModel> ConvertYandexResultToViewModel(YandexSearchResultModel yandexResult)
        {
            var searchResults = new List<SearchResultViewModel>();
            try
            {
                foreach(var item in yandexResult.Response.Results.Grouping.Group)
                {
                    searchResults.Add(new SearchResultViewModel
                    {
                        ResultName = item.Doc.Domain,
                        ResultUrl = item.Doc.Url,
                        SearchEngine = SearchEngine.Yandex
                    });

                    searchResults.Add(new SearchResultViewModel());
                }
            }

            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Yandex search result to ViewModel - "+ $"{ex.Message}");
            }

            return searchResults;
        }

        private List<SearchResultDto> ConvertYandexResultToDto(YandexSearchResultModel yandexResult, SearchEngineDto searchEngine)
        {
            var searchResults = new List<SearchResultDto>();
            try
            {
                foreach(var item in yandexResult.Response.Results.Grouping.Group)
                {
                    searchResults.Add(new SearchResultDto
                    {
                        ResultName = item.Doc.Domain,
                        ResultUrl = item.Doc.Url,
                        SearchEngine = searchEngine
                    });
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("There are some problems with converting Yandex search result to Dto - "+ $"{ex.Message}");
            }

            return searchResults;
        }

        #endregion

        #endregion
    }
}
