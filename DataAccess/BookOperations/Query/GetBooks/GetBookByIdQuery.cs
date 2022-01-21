using System;
using System.Linq;
using AutoMapper;
using Core;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).FirstOrDefault(e => e.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }

            var bvm = _mapper.Map<BookDetailViewModel>(book);
            return bvm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}