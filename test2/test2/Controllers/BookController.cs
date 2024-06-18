using Microsoft.AspNetCore.Mvc;
using test2.DTOs;
using test2.Services;

namespace test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] DateTime? releaseDate)
    {
        var books = await _bookService.GetBooksAsync(releaseDate);
        return Ok(books);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBook(AddBookDto addBookDto)
    {
        try
        {
            var createdBook = await _bookService.AddBookAsync(addBookDto);
            return CreatedAtAction(nameof(GetBooks), new { id = createdBook.IdBook }, createdBook);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}