using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class BuyModel : PageModel
    {
        //
        private IBookstoreRepository repository;

        //Constructor
        public BuyModel (IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Add cart
        public Cart Cart { get; set; }

        //Return URL
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); //***
        }

        //For post method
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //Remove items; Code from Textbook Ch. 9
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
