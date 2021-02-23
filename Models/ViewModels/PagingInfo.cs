using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    //For page numbers
    public class PagingInfo
    {
        //Total number of items
        public int TotalNumItems { get; set; }
        //Number of items to display on each page
        public int ItemsPerPage { get; set; }
        //The number of the page currently being viewed
        public int CurrentPage { get; set; }

        //Calculate the total number of pages
        public int TotalPages => (int) (Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
