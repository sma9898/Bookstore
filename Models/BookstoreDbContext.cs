using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Inherit from DbContext
    public class BookstoreDbContext : DbContext
    {
        //Constructor
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        //Property
        public DbSet<Book> Books { get; set; } 
    }
}
