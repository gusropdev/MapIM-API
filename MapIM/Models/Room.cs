namespace MapIM.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public string Slug { get; set; }
    public Floor Floor { get; set; }
    public Category Category { get; set; }
    public Department Department { get; set; }
    public int? DepartmentId { get; set; }
    public ICollection<Professor>? Professors { get; set; }
}
