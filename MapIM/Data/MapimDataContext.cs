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
    public DbSet<Category> Categories { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Floor> Floors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ProfessorMap());
        modelBuilder.ApplyConfiguration(new RoomMap());
        modelBuilder.ApplyConfiguration(new BlockMap());
        modelBuilder.ApplyConfiguration(new FloorMap());
    }
}
