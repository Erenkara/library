using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBookRepository: IRepository<Book> 
    {
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();
        Task<Book> GetWithAuthorByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId);
    }
}
