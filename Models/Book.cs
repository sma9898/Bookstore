using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Stores data for a book object
    public class Book
    {
        //Primary Key ID
        [Key] //Set up as auto-number primary key
        public int BookId { get; set; }

        //Book title, required
        [Required]
        public string BookTitle { get; set; }

        //Book author first name, required
        [Required]
        public string BookAuthorFirstName { get; set; }

        //Book author middle name or initial, not required
        public string BookAuthorMiddleName { get; set; }

        //Book author last name, required
        [Required]
        public string BookAuthorLastName { get; set; }

        //Book publisher, required
        [Required]
        public string BookPublisher { get; set; }

        //Book ISBN, required
        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{10}")]
        public string BookISBN { get; set; }

        //Book category, required
        [Required]
        public string BookCategory { get; set; }

        //Book price, required
        [Required]
        public double BookPrice { get; set; } //***Data type?

        //Number of pages in book
        public int BookPages { get; set; }

    }
}
