using Library.Core;
using Library.Core.Repositories;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Author> CreateAuthor(Author newAuthor)
        {
            await _unitOfWork.Authors.AddAsync(newAuthor);
            await _unitOfWork.CommitAsync();
            return newAuthor;
        }

        public async Task DeleteAuthor(Author author)
        {
            _unitOfWork.Authors.Remove(author);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _unitOfWork.Authors.GetAllAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task UpdateAuthor(Author authorToBeUpdated, Author author)
        {
            authorToBeUpdated.Name = author.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
