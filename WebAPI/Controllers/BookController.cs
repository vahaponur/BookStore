using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.BookOperations.CreateBook;
using DataAccess.BookOperations.DeleteBook;
using DataAccess.BookOperations.GetBooks;
using DataAccess.BookOperations.UpdateBook;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        
       

        [HttpGet]
        public IActionResult Get()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context);
            try
            {
                query.BookId = id;
                return Ok(query.Handle());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
     
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookCommand.CreateBookModel model)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.Model = model;
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