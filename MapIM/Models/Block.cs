namespace MapIM.Models;

public class Block
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public ICollection<Floor> Floors { get; set; }
}
