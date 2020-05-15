using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task<Author> CreateAuthor(Author newAuthor);
        Task UpdateAuthor(Author authorToBeUpdated, Author author);
        Task DeleteAuthor(Author author);
    }
}
