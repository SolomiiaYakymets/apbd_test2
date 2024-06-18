namespace test2.DTOs;

public class AddBookDto
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int IdPublishingHouse { get; set; }
    public List<int> AuthorIds { get; set; }
    public List<int> GenreIds { get; set; }
}