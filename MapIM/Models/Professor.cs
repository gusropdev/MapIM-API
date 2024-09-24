namespace MapIM.Models;

public class Professor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Email { get; set; }
    public Department Department { get; set; }
    public Room Room { get; set; }
}
