using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Components
{
    //Some kind of component
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        //Constructor
        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            //Set private variable
            repository = r;
        }

        //What is returned when called in _Layout
        public IViewComponentResult Invoke()
        {
            //Get type/category from url/route
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.BookCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
