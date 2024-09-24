using MapIM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapIM.Data.Mappings;

public class ProfessorMap : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(301, 1)
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

        builder.Property(x => x.Email)
               .IsRequired(false)
               .HasColumnName("Email")
               .HasColumnType("VARCHAR")
               .HasMaxLength(255)
               .IsUnicode(false);


        builder.HasIndex(x => x.Slug, "IX_Professor_Slug")
               .IsUnique();

        builder.HasOne(x => x.Department)
               .WithMany(x => x.Professors)
               .HasConstraintName("FK_Professor_Department")
               .OnDelete(DeleteBehavior.Restrict); ;

        builder.HasOne(x => x.Room)
               .WithMany(x => x.Professors)
               .HasConstraintName("FK_Professor_Room")
               .OnDelete(DeleteBehavior.Restrict); ;
    }
}
