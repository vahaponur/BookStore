using System;
using System.Collections.Generic;
using Entities;
using System.Linq;
using Core;
using Entities.Enums;

namespace DataAccess.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var booksList =_dbContext.Books.OrderBy(e => e.Id).ToList();
            List<BooksViewModel> viewModels = new List<BooksViewModel>();
            foreach (var book in booksList)
            {
                var bvm = new BooksViewModel
                {
                    Title = book.BookName,
                    Genre = ((GenreEnum) book.GenreId).ToDescription(),
                    PublishDate = book.PublishDate.Date.ToString(),
                    PageCount = book.PageCount
                    
                };
                viewModels.Add(bvm);
            }

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