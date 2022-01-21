using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorOperations.Query.GetAuthors
{
    public class GetAuthorsQuery
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAuthorsQueryViewModel> Handle()
        {
            var authors = _context.Authors.ToList();
            var models = _mapper.Map<List<GetAuthorsQueryViewModel>>(authors);
            return models;
        }
    }
    public class GetAuthorsQueryViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }

    }
}
