using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Context;

public class ApbdContext : DbContext
{
    public ApbdContext()
    {
    }
    
    public ApbdContext(DbContextOptions<ApbdContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {

        modelBuilder.Entity<BookAuthor>()

            .HasKey(ba => new { ba.IdBook, ba.IdAuthor });
 
        modelBuilder.Entity<BookAuthor>()

            .HasOne(ba => ba.Book)

            .WithMany(b => b.BookAuthors)

            .HasForeignKey(ba => ba.IdBook);
 
        modelBuilder.Entity<BookAuthor>()

            .HasOne(ba => ba.Author)

            .WithMany(a => a.BookAuthors)

            .HasForeignKey(ba => ba.IdAuthor);
 
        modelBuilder.Entity<BookGenre>()

            .HasKey(bg => new { bg.IdBook, bg.IdGenre });
 
        modelBuilder.Entity<BookGenre>()

            .HasOne(bg => bg.Book)

            .WithMany(b => b.BookGenres)

            .HasForeignKey(bg => bg.IdBook);
 
        modelBuilder.Entity<BookGenre>()

            .HasOne(bg => bg.Genre)

            .WithMany(g => g.BookGenres)

            .HasForeignKey(bg => bg.IdGenre);

    }

}