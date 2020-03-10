using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngines.Models;
using SearchEngines.Services;

namespace SearchEngines.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly SearchService _searchService;

        public SearchController(ILogger<SearchController> logger, SearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        /// <summary>
        /// Search in search engines
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Search()
        {
            var searchViewModel = new SearchViewModel
            {
                SearchResults = new List<SearchResultViewModel>()
            };
            return View(searchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchViewModel)
        {
            if(Enum.IsDefined(typeof(SearchEngine), searchViewModel.Request.SearchEngine) 
                && searchViewModel.Request.SearchString != null)
            {
                searchViewModel.SearchResults = await _searchService.SearchByPhraseInSearchEngine(searchViewModel.Request.SearchString, searchViewModel.Request.SearchEngine);
                return View(searchViewModel);
            }

            else
            {
                return View(new SearchViewModel());
            }
        }

        /// <summary>
        /// Search in DB
        /// </summary>
        [HttpGet]
        public IActionResult SearchInDb()
        {
            var searchViewModel = new SearchViewModel
            {
                SearchResults = new List<SearchResultViewModel>()
            };
            return View(searchViewModel);
        }

        /// <summary>
        /// Search in all stored results
        /// </summary>
        /// <param name="searchViewModel">View model for search in db</param>
        [HttpPost]
        public async Task<IActionResult> SearchInDb(SearchViewModel searchViewModel)
        {
            if(searchViewModel.Request.SearchString != null)
            {
                searchViewModel.SearchResults = await _searchService.SearchByPhraseInDb(searchViewModel.Request.SearchString);
                return View(searchViewModel);
            }
            else
            {
                return View(new SearchViewModel());
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
