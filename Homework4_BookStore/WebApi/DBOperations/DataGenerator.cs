using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                //Example Genre Datas
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Fantasy"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    }
                );

                //Example Aythor Datas
                context.Authors.AddRange(
                   new Author
                   {
                       FirstName = "J.K.",
                       LastName = "Rowling",
                       DateOfBirth = new DateTime(1965, 07, 31)
                   },
                    new Author
                    {
                        FirstName = "J.R.R.",
                        LastName = "Tolkien",
                        DateOfBirth = new DateTime(1892, 01, 03)
                    },
                    new Author
                    {
                        FirstName = "Philip",
                        LastName = "K. Dick",
                        DateOfBirth = new DateTime(1928, 12, 16)
                    }
                );

                //Example Book Datas
                context.Books.AddRange(
                     new Book
                     {
                         Id = 1,
                         Title = "Lean Startup",
                         GenreId = 1,
                         PageCount = 200,
                         PublishDate = new DateTime(2023, 06, 12)
                     },
            new Book
            {
                Id = 2,
                Title = "Herland",
                GenreId = 1,
                PageCount = 250,
                PublishDate = new DateTime(2023, 07, 12)
            },
            new Book
            {
                Id = 3,
                Title = "Dune",
                GenreId = 3,
                PageCount = 300,
                PublishDate = new DateTime(2023, 12, 21)
            },
            new Book
            {
                Id = 4,
                Title = "Harry Potter: Philosopher's Stone",
                GenreId = 2,
                PageCount = 223,
                PublishDate = new DateTime(2023, 05, 15)
            },
            new Book
            {
                Id = 5,
                Title = "Harry Potter: Chamber of Secrets",
                GenreId = 2,
                PageCount = 384,
                PublishDate = new DateTime(2023, 05, 20)
            },
            new Book
            {
                Id = 6,
                Title = "Harry Potter: Prisoner of Azkaban",
                GenreId = 2,
                PageCount = 448,
                PublishDate = new DateTime(2023, 05, 25)
            },
            new Book
            {
                Id = 7,
                Title = "The Hobbit",
                GenreId = 3,
                PageCount = 320,
                PublishDate = new DateTime(2023, 09, 10)
            },
            new Book
            {
                Id = 8,
                Title = "To Kill a Mockingbird",
                GenreId = 4,
                PageCount = 336,
                PublishDate = new DateTime(2023, 08, 5)
            },
            new Book
            {
                Id = 9,
                Title = "1984",
                GenreId = 4,
                PageCount = 328,
                PublishDate = new DateTime(2023, 04, 30)
            },
            new Book
            {
                Id = 10,
                Title = "The Great Gatsby",
                GenreId = 4,
                PageCount = 180,
                PublishDate = new DateTime(2023, 03, 15)
            }
                            );
                context.SaveChanges();
            }
        }
    }
}