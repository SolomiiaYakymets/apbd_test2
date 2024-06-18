using System.ComponentModel.DataAnnotations;

namespace test2.Models;

public class BookAuthor
{
    [Key]
    public int IdBook { get; set; }
    [Key]
    public int IdAuthor { get; set; }
    
    public Book Book { get; set; }
    public Author Author { get; set; }
}