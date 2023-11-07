using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Select Book By Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            query.Id = id;
            validator.ValidateAndThrow(query);
            BookViewModel vm = query.Handle();
            return Ok(vm);
        }

        //Select Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            List<BooksViewModel> vm = query.Handle();
            return Ok(vm);
        }

        //Create Book
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookCommandValidator validator = new CreateBookCommandValidator(_context);   
            command.Model = newBook;                     
            validator.ValidateAndThrow(command);
            command.Handle();       
            return Ok();
        }

        //Update Book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator(_context);
            command.Id = id;
            command.Model = updatedBook;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //Delete Book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            command.Id = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}