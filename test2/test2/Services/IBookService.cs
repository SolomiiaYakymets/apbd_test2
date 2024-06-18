using test2.DTOs;
using test2.Models;

namespace test2.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync(DateTime? releaseDate);
    Task<BookDto> AddBookAsync(AddBookDto addBookDto);
}