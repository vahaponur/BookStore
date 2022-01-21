using AutoMapper;
using Core;
using DataAccess.AuthorOperations.Query.GetAuthorById;
using DataAccess.AuthorOperations.Query.GetAuthors;
using DataAccess.BookOperations.CreateBook;
using DataAccess.BookOperations.GetBooks;
using DataAccess.GenreOperations.Commands;
using DataAccess.GenreOperations.Queries.GetGenreDetail;
using DataAccess.GenreOperations.Queries.GetGenres;
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
            #region Book
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(destinationMember =>
            destinationMember.Genre, opt => opt.MapFrom(src => src.Genre.Name)
            );
            CreateMap<Book, BooksViewModel>().ForMember(destinationMember =>
           destinationMember.Genre, opt => opt.MapFrom(src => src.Genre.Name)
           );
            #endregion

            #region Genre
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            #endregion
            #region Author
            CreateMap<Author, GetAuthorDetailViewModel>();
            CreateMap<Author, GetAuthorsQueryViewModel>();
            #endregion

        }
    }
}
