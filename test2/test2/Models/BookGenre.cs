using System.ComponentModel.DataAnnotations;

namespace test2.Models;

public class BookGenre
{
    [Key]
    public int IdGenre { get; set; }
    [Key]
    public int IdBook { get; set; }
    
    public Genre Genre { get; set; }
    public Book Book { get; set; }
}