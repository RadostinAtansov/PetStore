using PetStore.Data.Model;

namespace PetStore.Data.Configuration
{
    public class ToyOrder
    {
        public int ToyId { get; set; }
        public Toy Toy { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
