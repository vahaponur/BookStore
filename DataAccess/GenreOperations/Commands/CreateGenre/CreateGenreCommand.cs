using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        public CreateGenreModel GenreModel { get; set; }
        readonly BookStoreDbContext _dbContext;
        readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext dbContext,IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genreExist = _dbContext.Genres.FirstOrDefault(c => c.Name == GenreModel.Name);
            if (genreExist != null)
            {
                throw new InvalidOperationException("Bu başlıkta  bir genre zaten var!");
            }
            var genre = _mapper.Map<Genre>(GenreModel);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
        
    }
}
