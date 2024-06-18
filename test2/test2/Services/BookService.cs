using Microsoft.EntityFrameworkCore;
using test2.Context;
using test2.DTOs;
using test2.Models;

namespace test2.Services;

public class BookService : IBookService
{
    private readonly ApbdContext _context;

    public BookService(ApbdContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookDto>> GetBooksAsync(DateTime? releaseDate)
    {
        var query = _context.Books
            .Include(b => b.PublishingHouse)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
            .AsQueryable();

        if (releaseDate.HasValue)
        {
            query = query.Where(b => b.ReleaseDate >= releaseDate.Value);
        }

        var books = await query
            .OrderByDescending(b => b.ReleaseDate)
            .ThenBy(b => b.PublishingHouse.Name)
            .ToListAsync();

        return books.Select(b => new BookDto
        {
            IdBook = b.IdBook,
            Name = b.Name,
            ReleaseDate = b.ReleaseDate,
            PublishingHouseName = b.PublishingHouse.Name,
            Authors = b.BookAuthors.Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}").ToList(),
            Genres = b.BookGenres.Select(bg => bg.Genre.Name).ToList()
        }).ToList();
    }

    public async Task<BookDto> AddBookAsync(AddBookDto addBookDto)
    {
        if (!_context.PublishingHouses.Any(ph => ph.IdPublishingHouse == addBookDto.IdPublishingHouse))
        {
            throw new ArgumentException("Publishing House does not exist.");
        }

        var book = new Book
        {
            Name = addBookDto.Name,
            ReleaseDate = addBookDto.ReleaseDate,
            IdPublishingHouse = addBookDto.IdPublishingHouse,
            BookAuthors = addBookDto.AuthorIds.Select(id => new BookAuthor { IdAuthor = id }).ToList(),
            BookGenres = addBookDto.GenreIds.Select(id => new BookGenre { IdGenre = id }).ToList()
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return new BookDto
        {
            IdBook = book.IdBook,
            Name = book.Name,
            ReleaseDate = book.ReleaseDate,
            PublishingHouseName = _context.PublishingHouses
                .FirstOrDefault(ph => ph.IdPublishingHouse == book.IdPublishingHouse)?.Name,
            Authors = book.BookAuthors.Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}").ToList(),
            Genres = book.BookGenres.Select(bg => bg.Genre.Name).ToList()
        };
    }
    
}