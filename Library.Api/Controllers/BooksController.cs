using AutoMapper;
using Library.Api.Resources;
using Library.Api.Validators;
using Library.Core;
using Library.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            this._bookService = bookService;
            this._mapper = mapper;

        }
        [Authorize]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookService.GetAllWithAuthor();
            var bookResource = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);
            return Ok(bookResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById (int id)
        {
            var book = await _bookService.GetBookById(id);
            var bookResource = _mapper.Map<Book, BookResource> (book);
            return Ok(bookResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<BookResource>> CreateBook([FromBody] SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBookResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var bookToCreate = _mapper.Map<SaveBookResource, Book>(saveBookResource);

            var newBook = await _bookService.CreateBook(bookToCreate);

            var book = await _bookService.GetBookById(newBook.Id);

            var bookResource = _mapper.Map<Book, BookResource>(book);

            return Ok(bookResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookResource>> UpdateBook(int id, [FromBody] SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBookResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); 

            var bookToBeUpdate = await _bookService.GetBookById(id);

            if (bookToBeUpdate == null)
                return NotFound();

            var book = _mapper.Map<SaveBookResource, Book>(saveBookResource);

            await _bookService.UpdateBook(bookToBeUpdate, book);

            var updatedBook = await _bookService.GetBookById(id);
            var updatedBookResource = _mapper.Map<Book, BookResource>(updatedBook);

            return Ok(updatedBookResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest();

            var book = await _bookService.GetBookById(id);

            if (book == null)
                return NotFound();

            await _bookService.DeleteBook(book); 

            return NoContent();
        }

    }
}
