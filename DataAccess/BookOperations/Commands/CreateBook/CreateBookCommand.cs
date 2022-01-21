using System;
using Entities;
using System.Linq;
using AutoMapper;

namespace DataAccess.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var bookExist = _dbContext.Books.SingleOrDefault(e => e.Title == Model.Title) != null;
            if (bookExist)
            {
                throw new InvalidOperationException("Bu başlıkta  bir kitap zaten var!");
            }

            var book = _mapper.Map<Book>(Model);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
       
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}