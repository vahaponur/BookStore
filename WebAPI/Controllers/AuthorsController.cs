using AutoMapper;
using DataAccess;
using DataAccess.AuthorOperations.Command;
using DataAccess.AuthorOperations.Query.GetAuthorById;
using DataAccess.AuthorOperations.Query.GetAuthors;
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
    public class AuthorsController : ControllerBase
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public AuthorsController(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var query = new GetAuthorsQuery(_context, _mapper);
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId = id;
            return Ok(query.Handle());
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateAuthorViewModel model)
        {
            var command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;
            var validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(command);
            return Ok();
        }
    }
}
