using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IAuthorRepository: IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        Task<Author> GetWithBooksByIdAsync(int id);
    }
}
