using MapIM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapIM.Data.Mappings;

public class RoomMap : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(101, 1)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Number)
               .HasColumnName("Number")
               .HasColumnType("INT");

        builder.Property(x => x.Slug)
               .IsRequired()
               .HasColumnName("Slug")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Floor)
               .IsRequired()
               .HasColumnName("Floor")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Category)
               .IsRequired()
               .HasColumnName("Category")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Block)
               .IsRequired()
               .HasColumnName("Block")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.HasIndex(x => x.Slug, "IX_Room_Slug")
               .IsUnique();

        builder.HasOne(x => x.Department)
               .WithMany(x => x.Rooms)
               .HasForeignKey(x => x.DepartmentId)
               .HasConstraintName("FK_Room_Department")
               .OnDelete(DeleteBehavior.SetNull);


    }
}
