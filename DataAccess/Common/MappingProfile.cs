using AutoMapper;
using Core;
using DataAccess.BookOperations.CreateBook;
using DataAccess.BookOperations.GetBooks;
using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DataAccess.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(destinationMember =>
            destinationMember.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToDescription())
            );
            CreateMap<Book, BooksViewModel>().ForMember(destinationMember =>
           destinationMember.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToDescription())
           );
        }
    }
}
