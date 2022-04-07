using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Model;

namespace PetStore.Data.Configuration
{
    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> foodOrder)
        {
            foodOrder.HasKey(fo => new { fo.FoodId, fo.OrderId });

            foodOrder
                .HasOne(fo => fo.Food)
                .WithMany(f => f.Orders)
                .HasForeignKey(k => k.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            foodOrder
               .HasOne(fo => fo.Order)
               .WithMany(f => f.Foods)
               .HasForeignKey(k => k.OrderId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
