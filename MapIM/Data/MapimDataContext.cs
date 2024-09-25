using MapIM.Data.Mappings;
using MapIM.Models;
using Microsoft.EntityFrameworkCore;

namespace MapIM.Data;

public class MapimDataContext : DbContext
{
    public MapimDataContext(DbContextOptions<MapimDataContext> options)
        : base(options)
    {

    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentMap());
        modelBuilder.ApplyConfiguration(new ProfessorMap());
        modelBuilder.ApplyConfiguration(new RoomMap());
    }
}
