using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .UseHiLo("product_hilo")
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired(false);

        builder.Property(p => p.Price)
            .IsRequired(true);

        builder.Property(p => p.PictureFileName)
            .IsRequired(false);

        builder.Property(p => p.CountProduct);

        builder.Property(p => p.Available);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

        builder.HasOne(p => p.Manufacture)
            .WithMany()
            .HasForeignKey(p => p.ManufactureId);
    }
}