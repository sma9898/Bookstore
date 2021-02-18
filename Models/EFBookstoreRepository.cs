using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Inherit from IBookstoreRepository
    public class EFBookstoreRepository : IBookstoreRepository
    {
        //Private variable
        private BookstoreDbContext _context;

        //Constructor
        public EFBookstoreRepository (BookstoreDbContext context)
        {
            _context = context;
        }

        //Set
        public IQueryable<Book> Books => _context.Books;
    }
}
