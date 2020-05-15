using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Resources
{
    public class SaveBookResource
    {
        public string Name { get; set; } 
        public String ISBN { get; set; }
        public int AuthorId { get; set; }
    }
}
