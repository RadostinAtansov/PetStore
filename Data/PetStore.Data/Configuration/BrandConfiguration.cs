using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Model;

namespace PetStore.Data.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> brand)
        {
            brand
                   .HasMany(f => f.Foods)
                   .WithOne(b => b.Brand)
                   .HasForeignKey(k => k.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);

            brand
                .HasMany(t => t.Toys)
                .WithOne(b => b.Brand)
                .HasForeignKey(k => k.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
