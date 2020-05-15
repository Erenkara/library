using Library.Core;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context): base(context)
        { }
        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await LibraryDbContext.Authors
                 .Include(m => m.Books)
                 .ToListAsync();
        }

        public async Task<Author> GetWithBooksByIdAsync(int id)
        {
            return await LibraryDbContext.Authors
                .Include(m => m.Books)
                .SingleOrDefaultAsync(m => m.Id == id);
        }
        private LibraryDbContext LibraryDbContext
        {
            get { return Context as LibraryDbContext; }
        }
    }
}
