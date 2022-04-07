
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Model;

namespace PetStore.Data.Configuration
{
    public class CategoryConfiguraion : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                 .HasMany(p => p.Pets)
                 .WithOne(c => c.Category)
                 .HasForeignKey(k => k.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            category
                .HasMany(t => t.Toys)
                .WithOne(c => c.Category)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            category
                .HasMany(f => f.Foods)
                .WithOne(c => c.Category)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
