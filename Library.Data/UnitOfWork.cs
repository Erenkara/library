using Library.Core;
using Library.Core.Repositories;
using Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;

        public UnitOfWork(LibraryDbContext context)
        {
            this._context = context;
        }

        //access to all repositories with one context(librarydbcontext) 
        public IBookRepository Books => _bookRepository = _bookRepository ?? new BookRepository(_context);

        public IAuthorRepository Authors => _authorRepository = _authorRepository ?? new AuthorRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
