namespace MapIM.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
