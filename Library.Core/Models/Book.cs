using System;
using System.Net;

namespace Library.Core
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ISBN { get; set; }
        public int AuthorId { get; set; }
        public Author  Author { get; set; }
    }

}
