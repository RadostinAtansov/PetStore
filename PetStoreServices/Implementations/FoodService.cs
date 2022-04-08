namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Data.Model;
    using PetStore.Services.Model.Food;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public FoodService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void Buy(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or whitespace!");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit must be highter than zero and lower than 500%");
            }

            var food = new Food() 
            {
                Name = name,
                Weight = weight,
                Price = price + (price * (decimal)profit),
                DataExpire = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId,
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cannot be null or white sspace");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit must be highter than zero and lower than 500%");
            }

            var food = new Food()
            {
                Name = name,
                Weight = weight,
                DestributorPrice = price,
                Price = price + (price * (decimal)profit),
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public bool Exist(int foodId)
        {
            return this.data.Foods.Any(f => f.Id == foodId);
        }

        public void SellFoodToUser(int foodId, int userId)
        {

            if (!this.Exist(foodId))
            {
                throw new ArgumentException("there is no such food with this given id in the database!");
            }

            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user with the given id in database!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };

            var foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order, 
            };

            this.data.Orders.Add(order);
            this.data.FoodOrders.Add(foodOrder);
            this.data.SaveChanges();
        }
    }
}