﻿using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels; //Added

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookstoreRepository _repository; //New private repository

        //
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository) //Added IBookstoreRepository repository
        {
            _logger = logger;
            _repository = repository; //Assign the value
        }

        public IActionResult Index(string category, int page = 1) //Pass in page to go to. Default is page 1
        {
            //Pass in info
            return View(new BookListViewModel
            {
                Books = _repository.Books
                .Where(p => category == null || p.BookCategory == category) //Get right category or all if none selected
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //If no category selected, use total, else use total in selected category
                    TotalNumItems = category == null ? _repository.Books.Count() :
                    _repository.Books.Where (x => x.BookCategory == category).Count()
                },
                CurrentCategory = category

            });
                
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
