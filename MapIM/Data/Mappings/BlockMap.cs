using MapIM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapIM.Data.Mappings;

public class BlockMap : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(401, 1)
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

        builder.HasIndex(x => x.Slug, "IX_Block_Slug")
               .IsUnique();
    }
}
