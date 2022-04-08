using PetStore.Data;
using PetStore.Data.Model;
using PetStore.Services.Model.Toy;

namespace PetStore.Services.Implementations
{
    public class ToyService : IToyService
    {
        
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public ToyService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void BuyFromDistributor(string name, string description, decimal distributor, double profit, int brandId, int categoryId)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null ot whitespace!w");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit cannot be less than zero and more than 5!");
            }

            var toy = new Toy
            {
                Name = name,
                Description = description,
                DestributorPRice = distributor,
                Price = distributor + (distributor * (decimal)profit),
                BrandId = brandId,
                CategoryId = categoryId
            };
            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingToyServiceModel model)
        {
            var toy = new Toy
            {
                Name = model.Name,
                Description = model.Description,
                DestributorPRice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public void SellToyToUser(int toyId, int userId)
        {
            if (!this.Exists(toyId))
            {
                throw new ArgumentException("There is no such toy in database!");
            }

            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user with the given id in database");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };

            var toyOrder = new ToyOrder()
            {
                ToyId = toyId,
                Order = order,
            };

            this.data.Orders.Add(order);
            this.data.ToyOrders.Add(toyOrder);

            this.data.SaveChanges();
        }

        public bool Exists(int toyId)
        {
            return this.data.Toys.Any(t => t.Id == toyId);  
        }
    }
}
