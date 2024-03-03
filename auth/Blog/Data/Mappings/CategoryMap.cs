using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    // Fluent Mapping EFCore
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Table
        builder.ToTable("Category");

        // Primary key
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); // PRIMARY KEY IDENTITY (1, 1)

        //Properties
        builder.Property(x => x.Name)
            .IsRequired() // NOT NULL
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired() // NOT NULL
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        // Indexes
        builder.HasIndex(x => x.Slug, "IX_Category_Slug")
            .IsUnique();
    }
}