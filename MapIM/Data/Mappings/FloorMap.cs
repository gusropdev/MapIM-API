using MapIM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapIM.Data.Mappings;

public class FloorMap : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(451, 1)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Slug)
               .IsRequired()
               .HasColumnName("Slug")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.HasIndex(x => x.Slug, "IX_Floor_Slug")
               .IsUnique();

        builder.HasOne(x => x.Block)
               .WithMany(x => x.Floors)
               .HasConstraintName("FK_Floor_Block")
               .OnDelete(DeleteBehavior.Restrict);
    }
}
