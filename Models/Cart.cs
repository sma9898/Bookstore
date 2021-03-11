using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        //
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //Add book to cart
        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault(); //Get first

            //If no line, create new line
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            //If line exists, add the quantity to the total
            else
            {
                line.Quantity += qty;
            }
        }

        //Remove an item from cart
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //Empty cart
        public virtual void Clear() => Lines.Clear(); //*** Add "virtual" before void?

        //Calculate cost of cart
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.BookPrice * e.Quantity); //Added (decimal) to cast
        


        //Info to store for each cart item
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }

    }
}
