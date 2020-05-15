using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Resources
{
    public class BookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public AuthorResource Author{ get; set; }
    }
}
