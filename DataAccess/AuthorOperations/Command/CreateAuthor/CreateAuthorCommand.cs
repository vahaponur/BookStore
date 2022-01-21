using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AuthorOperations.Command
{
    public class CreateAuthorCommand
    {
        public CreateAuthorViewModel Model { get; set; }
        BookStoreDbContext _context;
        IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var mapped = _mapper.Map<Author>(Model);
            var author = _context.Authors.SingleOrDefault(c => c.BirthOfDate == mapped.BirthOfDate && c.FirstName == mapped.FirstName && c.LastName == mapped.LastName);
            if (author != null)
            {
                throw new InvalidOperationException("Böyle bir yazar zaten var");
            }
            _context.Authors.Add(mapped);
            _context.SaveChanges();

        }
    }

    public class CreateAuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}
