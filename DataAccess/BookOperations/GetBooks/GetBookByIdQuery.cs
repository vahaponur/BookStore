using System;
using System.Linq;
using Core;
using Entities.Enums;

namespace DataAccess.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(e => e.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }

            var bvm = new BookViewModel
            {
                Genre = ((GenreEnum)book.GenreId).ToDescription(),
                Title = book.BookName,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.ToString()
            };
            return bvm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}