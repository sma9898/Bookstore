using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
namespace Bookstore.Components
{
    //From Textbook Ch. 9
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}