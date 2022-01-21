using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorOperations.Query.GetAuthorById
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetAuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == AuthorId);
            if (author==null)
            {
                throw new InvalidOperationException("Yok böyle bi yazar");
            }
            var authorModel = _mapper.Map<GetAuthorDetailViewModel>(author);
            return authorModel;
        }
    }
    public class GetAuthorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }

    }
}
