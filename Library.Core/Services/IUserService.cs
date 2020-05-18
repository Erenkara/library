using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password); 
    }
}
