using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Model;

namespace PetStore.Data.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> pet)
        {
            pet
                   .HasOne(b => b.Breed)
                   .WithMany(p => p.Pets)
                   .HasForeignKey(k => k.BreedId)
                   .OnDelete(DeleteBehavior.Restrict);

            pet
                .HasOne(p => p.Order)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            pet
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
        }
    }
}
