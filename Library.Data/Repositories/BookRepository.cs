using Library.Core;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context)
           : base(context)
        { }
        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync()
        {
            return await LibraryDbContext.Books
               .Include(m => m.Author)
               .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int Author)
        {
            return await LibraryDbContext.Books
                .Include(m => m.Author)
                .Where(m => m.AuthorId == Author)
                .ToListAsync();
        }

        public async Task<Book> GetWithAuthorByIdAsync(int id)
        {
            return await LibraryDbContext.Books
                   .Include(m => m.Author)
                   .SingleOrDefaultAsync(m => m.Id == id); ;
        }
        private LibraryDbContext LibraryDbContext
        {
            get { return Context as LibraryDbContext; }
        }
    }
}
