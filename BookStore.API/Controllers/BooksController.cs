using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        // to get the data from repository
        // we have to inject it here using constructors
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookbyId([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookbyIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            //return Ok(books);
            return CreatedAtAction(nameof(GetBookbyId), new { id = id, Controller = "books" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel,[FromRoute]int id)
        {
             await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok();
            
        }
        /*[HttpGet("ri/{sdf}")]
        public IActionResult kaam (int sdf)
        {
            return Ok(sdf);
        }*/
    }
}
