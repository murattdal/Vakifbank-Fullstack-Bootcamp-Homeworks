using Homework1_BookStore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Homework1_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Sefiller",
                GenreId = 1,//Personel Growth
                PageCount = 200,
                PublishDate = new DateTime(2016,09,14)
            },

            new Book()
            {
                Id = 2,
                Title = "Suç ve Ceza",
                GenreId = 2,
                PageCount = 250,
                PublishDate = new DateTime(2014,02,05)
            },

             new Book()
            {
                Id = 3,
                Title = "1984",
                GenreId = 2,
                PageCount = 540,
                PublishDate = new DateTime(2010,08,14)
            },

             new Book()
            {
                Id = 4,
                Title = "Karamazov Kardeşler",
                GenreId = 2,
                PageCount = 540,
                PublishDate = new DateTime(2010,08,14)
            },

        };

        [HttpGet]
        [Route("GetAll")]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();

            return bookList;
        }

        [HttpGet]
        [Route("GetById")]
        public Book GetById([FromQuery] int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();

            return book;
        }


        [HttpPost]
        [Route("BookCreate")]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();//validation

            BookList.Add(newBook);

            return Ok();

        }

        [HttpPut]
        [Route("BookUpdate")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();//validation

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;

            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;

            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            return Ok();

        }


        [HttpDelete]
        [Route("BookDelete")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();//validation

            BookList.Remove(book);

            return Ok();
        }


        //[HttpPatch("{id}")]
        //public IActionResult PatchBook(int id, [FromBody] JsonPatchDocument<Book> patchDocument)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Id == id);

        //    if (book is null)
        //        return BadRequest();//validation

        //    if (patchDocument is null)
        //        return BadRequest();//validation

        //    patchDocument.ApplyTo(book);

        //    return Ok();
        //}

    }
}
