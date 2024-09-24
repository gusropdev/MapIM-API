﻿namespace MapIM.Models;

public class Floor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public Block Block { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
