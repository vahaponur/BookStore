using System;
using System.Collections.Generic;
using Entities;
using System.Linq;
using Core;
using Entities.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var booksList =_dbContext.Books.Include(s=>s.Genre).OrderBy(e => e.Id).ToList();
            List<BooksViewModel> viewModels = _mapper.Map<List<BooksViewModel>>(booksList);
            //foreach (var book in booksList)
            //{
            //    var bvm = new BooksViewModel
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum) book.GenreId).ToDescription(),
            //        PublishDate = book.PublishDate.Date.ToString(),
            //        PageCount = book.PageCount
                    
            //    };
            //    viewModels.Add(bvm);
            //}

            return viewModels;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}