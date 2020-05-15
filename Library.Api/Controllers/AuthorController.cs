using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Api.Resources;
using Library.Api.Validators;
using Library.Core;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc; 

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            this._mapper = mapper;
            this._authorService = authorService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AuthorResource>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            var authorResources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);

            return Ok(authorResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResource>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorById(id);
            var authorResource = _mapper.Map<Author, AuthorResource>(author);

            return Ok(authorResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<AuthorResource>> CreateAuthor([FromBody] SaveAuthorResource saveAuthorResource)
        {
            var validator = new SaveAuthorResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAuthorResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var authorToCreate = _mapper.Map<SaveAuthorResource, Author>(saveAuthorResource);

            var newAuthor = await _authorService.CreateAuthor(authorToCreate);

            var author = await _authorService.GetAuthorById(newAuthor.Id);

            var authorResource = _mapper.Map<Author, AuthorResource>(author);

            return Ok(authorResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorResource>> UpdateAuthor(int id, [FromBody] SaveAuthorResource saveAuthorResource)
        {
            var validator = new SaveAuthorResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAuthorResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var authorToBeUpdated = await _authorService.GetAuthorById(id);

            if (authorToBeUpdated == null)
                return NotFound();

            var author = _mapper.Map<SaveAuthorResource, Author>(saveAuthorResource);

            await _authorService.UpdateAuthor(authorToBeUpdated, author);

            var updatedAuthor = await _authorService.GetAuthorById(id);

            var updatedAuthorResource = _mapper.Map<Author, AuthorResource>(updatedAuthor);

            return Ok(updatedAuthorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetAuthorById(id);

            await _authorService.DeleteAuthor(author);

            return NoContent();
        }
    }
}