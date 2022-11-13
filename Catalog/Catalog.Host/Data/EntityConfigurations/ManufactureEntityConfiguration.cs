using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class ManufactureEntityConfiguration : IEntityTypeConfiguration<Manufacture>
{
    public void Configure(EntityTypeBuilder<Manufacture> builder)
    {
        builder.ToTable("manufactures");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .UseHiLo("manufacture_hilo")
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
