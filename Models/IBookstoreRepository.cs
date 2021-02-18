using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Repository, template
    //Change from class to interface
    public interface IBookstoreRepository
    {
        //Queryable
        IQueryable<Book> Books { get; }
    }
}
