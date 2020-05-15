using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllWithAuthor();
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);
        Task<Book> CreateBook(Book newBook);
        Task UpdateBook(Book bookToBeUpdated, Book book);
        Task DeleteBook(Book book);

    }
}
