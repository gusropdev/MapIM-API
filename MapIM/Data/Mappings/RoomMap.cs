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
               .IsRequired()
               .HasColumnName("Number")
               .HasColumnType("INT");

        builder.Property(x => x.Slug)
               .IsRequired()
               .HasColumnName("Slug")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.HasIndex(x => x.Slug, "IX_Room_Slug")
               .IsUnique();

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Rooms)
               .HasConstraintName("FK_Room_Category")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Floor)
               .WithMany(x => x.Rooms)
               .HasConstraintName("FK_Room_Floor")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
               .WithMany(x => x.Rooms)
               .HasForeignKey(x => x.DepartmentId)
               .HasConstraintName("FK_Room_Department")
               .OnDelete(DeleteBehavior.SetNull);


    }
}
