using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get;  }
        IAuthorRepository Authors { get;  }
        Task<int> CommitAsync();
    }
}
