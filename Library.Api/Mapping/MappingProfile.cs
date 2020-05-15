using AutoMapper;
using Library.Api.Resources;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Book, BookResource>();
            CreateMap<Author, AuthorResource>();


            CreateMap<BookResource, Book>();
            CreateMap<AuthorResource, Author>();
            CreateMap<SaveAuthorResource, Author>();
            CreateMap<SaveBookResource, Book>();

        }
    }
}
