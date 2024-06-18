using System.ComponentModel.DataAnnotations;

namespace test2.Models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public int IdPublishingHouse { get; set; }

    public PublishingHouse PublishingHouse { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
}