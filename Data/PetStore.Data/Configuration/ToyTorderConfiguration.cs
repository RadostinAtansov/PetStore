
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetStore.Data.Configuration
{
    public class ToyTorderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder.HasKey(to => new { to.OrderId, to.ToyId });

            toyOrder
                .HasOne(o => o.Order)
                .WithMany(t => t.Toys)
                .HasForeignKey(k => k.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            toyOrder
                .HasOne(t => t.Toy)
                .WithMany(o => o.Orders)
                .HasForeignKey(k => k.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
