namespace test2.DTOs;

public class BookDto
{
    public int IdBook { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PublishingHouseName { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Genres { get; set; }
}