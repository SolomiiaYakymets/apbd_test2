using System.ComponentModel.DataAnnotations;

namespace test2.Models;

public class PublishingHouse
{
    [Key]
    public int IdPublishingHouse { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Country { get; set; }
    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    public ICollection<Book> Books { get; set; }
}