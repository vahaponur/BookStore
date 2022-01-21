using AutoMapper;
using DataAccess;
using DataAccess.GenreOperations.Commands;
using DataAccess.GenreOperations.Commands.DeleteGenre;
using DataAccess.GenreOperations.Queries.GetGenreDetail;
using DataAccess.GenreOperations.Queries.GetGenres;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        readonly BookStoreDbContext _context;
        IMapper _mapper;

        public GenresController(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var query = new GetGenresQuery(_context, _mapper);
            var genres = query.Handle();
            return Ok(genres);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;
            var validator = new GetGenreDetailValidator();
            validator.ValidateAndThrow(query);
            return Ok(query.Handle());

        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreModel genreModel)
        {
            var command = new CreateGenreCommand(_context, _mapper);
            command.GenreModel = genreModel;
            var validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteGenreCommand(_context,_mapper);
            command.GenreId = id;
            command.Handle();
            return Ok();
        }

    }
}
