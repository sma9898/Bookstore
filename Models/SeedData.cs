using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public static class SeedData
    {
        //?
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    //Default seeded list of books

                    new Book
                    {
                        BookTitle = "Les Miserables",
                        BookAuthorFirstName = "Victor",
                        BookAuthorLastName = "Hugo",
                        BookPublisher = "Signet",
                        BookISBN = "978-0451419439",
                        BookCategory = "Fiction, Classic",
                        BookPrice = 9.95D
                    },
                    new Book
                    {
                        BookTitle = "Team of Rivals",
                        BookAuthorFirstName = "Doris",
                        BookAuthorMiddleName = "Kearns",
                        BookAuthorLastName = "Goodwin",
                        BookPublisher = "Simon & Schuster",
                        BookISBN = "978-0743270755",
                        BookCategory = "Non-Fiction, Biography",
                        BookPrice = 14.58D
                    },
                    new Book
                    {
                        BookTitle = "The Snowball",
                        BookAuthorFirstName = "Alice",
                        BookAuthorLastName = "Schroeder",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553384611",
                        BookCategory = "Non-Fiction, Biography",
                        BookPrice = 21.54D
                    },
                    new Book
                    {
                        BookTitle = "American Ulysses",
                        BookAuthorFirstName = "Ronald",
                        BookAuthorMiddleName = "C.",
                        BookAuthorLastName = "White",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812981254",
                        BookCategory = "Non-Fiction, Biography",
                        BookPrice = 11.61D
                    },
                    new Book
                    {
                        BookTitle = "Unbroken",
                        BookAuthorFirstName = "Laura",
                        BookAuthorLastName = "Hilllenbrand",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812974492",
                        BookCategory = "Non-Fiction, Historical",
                        BookPrice = 13.33D
                    },
                    new Book
                    {
                        BookTitle = "The Great Train Robbery",
                        BookAuthorFirstName = "Michael",
                        BookAuthorLastName = "Crichton",
                        BookPublisher = "Vintage",
                        BookISBN = "978-0804171281",
                        BookCategory = "Fiction, Historical Fiction",
                        BookPrice = 15.95D
                    },
                    new Book
                    {
                        BookTitle = "Deep Work",
                        BookAuthorFirstName = "Cal",
                        BookAuthorLastName = "Newport",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455586691",
                        BookCategory = "Non-Fiction, Self-Help",
                        BookPrice = 14.99D
                    },
                    new Book
                    {
                        BookTitle = "It's Your Ship",
                        BookAuthorFirstName = "Michael",
                        BookAuthorLastName = "Abrashoff",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455523023",
                        BookCategory = "Non-Fiction, Self-Help",
                        BookPrice = 21.66D
                    },
                    new Book
                    {
                        BookTitle = "The Virgin Way",
                        BookAuthorFirstName = "Richard",
                        BookAuthorLastName = "Branson",
                        BookPublisher = "Portfolio",
                        BookISBN = "978-1591847984",
                        BookCategory = "Non-Fiction, Business",
                        BookPrice = 29.16D
                    },
                    new Book
                    {
                        BookTitle = "Sycamore Row",
                        BookAuthorFirstName = "John",
                        BookAuthorLastName = "Grisham",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553393613",
                        BookCategory = "Fiction, Thrillers",
                        BookPrice = 15.03D
                    }


                    );
            }
            context.SaveChanges();
        }
    }
}
