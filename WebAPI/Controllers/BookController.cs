using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using DataAccess.BookOperations.CreateBook;
using DataAccess.BookOperations.DeleteBook;
using DataAccess.BookOperations.GetBooks;
using DataAccess.BookOperations.UpdateBook;
using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public BookController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult Get()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
            try
            {
                query.BookId = id;
                GetBookByIdValidator validator = new GetBookByIdValidator();
                validator.ValidateAndThrow(query);
                return Ok(query.Handle());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
     
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookModel model)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);

            try
            {
                command.Model = model;
                CreateBookCommandValidator validations = new CreateBookCommandValidator();
                validations.ValidateAndThrow(command);
           
                command.Handle();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBookModel model)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model = model;
                command.BookId = id;
                UpdateBookValidator validations = new UpdateBookValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
                return Ok("Kitap güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            

            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok("Silindi");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

   
        }

    }
}