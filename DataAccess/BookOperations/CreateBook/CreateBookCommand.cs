using System;
using Entities;
using System.Linq;
namespace DataAccess.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var bookExist = _dbContext.Books.SingleOrDefault(e => e.BookName == Model.Title) != null;
            if (bookExist)
            {
                throw new InvalidOperationException("Bu başlıkta  bir kitap zaten var!");
            }

            var book = new Book
            {
                BookName = Model.Title,
                GenreId = Model.GenreId,
                PageCount = Model.PageCount,
                PublishDate = Model.PublishDate
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
        public class  CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}