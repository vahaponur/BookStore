using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        readonly BookStoreDbContext _dbContext;
        readonly IMapper _mapper;
        public DeleteGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genreToDelete = _dbContext.Genres.SingleOrDefault(g=>g.Id == GenreId);
            if (genreToDelete == null)
            {
                throw new InvalidOperationException("Böyle bi genre yok");
            }
            _dbContext.Remove(genreToDelete);
            _dbContext.SaveChanges();
        }
    }
}
