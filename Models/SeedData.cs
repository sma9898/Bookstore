﻿using Microsoft.AspNetCore.Builder;
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
                        BookClassification = "Fiction",
                        BookCategory = "Classic",
                        BookPrice = 9.95D,
                        BookPages = 1488
                    },
                    new Book
                    {
                        BookTitle = "Team of Rivals",
                        BookAuthorFirstName = "Doris",
                        BookAuthorMiddleName = "Kearns",
                        BookAuthorLastName = "Goodwin",
                        BookPublisher = "Simon & Schuster",
                        BookISBN = "978-0743270755",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 14.58D,
                        BookPages = 944
                    },
                    new Book
                    {
                        BookTitle = "The Snowball",
                        BookAuthorFirstName = "Alice",
                        BookAuthorLastName = "Schroeder",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553384611",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 21.54D,
                        BookPages = 832
                    },
                    new Book
                    {
                        BookTitle = "American Ulysses",
                        BookAuthorFirstName = "Ronald",
                        BookAuthorMiddleName = "C.",
                        BookAuthorLastName = "White",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812981254",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Biography",
                        BookPrice = 11.61D,
                        BookPages = 864
                    },
                    new Book
                    {
                        BookTitle = "Unbroken",
                        BookAuthorFirstName = "Laura",
                        BookAuthorLastName = "Hilllenbrand",
                        BookPublisher = "Random House",
                        BookISBN = "978-0812974492",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Historical",
                        BookPrice = 13.33D,
                        BookPages = 528
                    },
                    new Book
                    {
                        BookTitle = "The Great Train Robbery",
                        BookAuthorFirstName = "Michael",
                        BookAuthorLastName = "Crichton",
                        BookPublisher = "Vintage",
                        BookISBN = "978-0804171281",
                        BookClassification = "Fiction",
                        BookCategory = "Historical Fiction",
                        BookPrice = 15.95D,
                        BookPages = 288
                    },
                    new Book
                    {
                        BookTitle = "Deep Work",
                        BookAuthorFirstName = "Cal",
                        BookAuthorLastName = "Newport",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455586691",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Self-Help",
                        BookPrice = 14.99D,
                        BookPages = 304
                    },
                    new Book
                    {
                        BookTitle = "It's Your Ship",
                        BookAuthorFirstName = "Michael",
                        BookAuthorLastName = "Abrashoff",
                        BookPublisher = "Grand Central Publishing",
                        BookISBN = "978-1455523023",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Self-Help",
                        BookPrice = 21.66D,
                        BookPages = 240
                    },
                    new Book
                    {
                        BookTitle = "The Virgin Way",
                        BookAuthorFirstName = "Richard",
                        BookAuthorLastName = "Branson",
                        BookPublisher = "Portfolio",
                        BookISBN = "978-1591847984",
                        BookClassification = "Non-Fiction",
                        BookCategory = "Business",
                        BookPrice = 29.16D,
                        BookPages = 400
                    },
                    new Book
                    {
                        BookTitle = "Sycamore Row",
                        BookAuthorFirstName = "John",
                        BookAuthorLastName = "Grisham",
                        BookPublisher = "Bantam",
                        BookISBN = "978-0553393613",
                        BookClassification = "Fiction",
                        BookCategory = "Thrillers",
                        BookPrice = 15.03D,
                        BookPages = 642
                    },

                    //My top 3 books
                    new Book
                    {
                        BookTitle = "The Way of Kings",
                        BookAuthorFirstName = "Brandon",
                        BookAuthorLastName = "Sanderson",
                        BookPublisher = "Tor Books",
                        BookISBN = "978-0765326355",
                        BookClassification = "Fiction",
                        BookCategory = "High Fantasy",
                        BookPrice = 9.59D,
                        BookPages = 1007
                    },
                    new Book
                    {
                        BookTitle = "The Lightning Thief",
                        BookAuthorFirstName = "Rick",
                        BookAuthorLastName = "Riordan",
                        BookPublisher = "Miramax Books",
                        BookISBN = "978-0786856297",
                        BookClassification = "Fiction",
                        BookCategory = "Fantasy",
                        BookPrice = 5.98D,
                        BookPages = 377
                    },
                    new Book
                    {
                        BookTitle = "The Hitchhiker's Guide to the Galaxy",
                        BookAuthorFirstName = "Douglas",
                        BookAuthorLastName = "Adams",
                        BookPublisher = "Pan Books",
                        BookISBN = "978-0330258648",
                        BookClassification = "Fiction",
                        BookCategory = "Comic Science Fiction",
                        BookPrice = 7.99D,
                        BookPages = 224
                    }


                    );
            }
            context.SaveChanges();
        }
    }
}
