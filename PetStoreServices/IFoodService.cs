using PetStore.Services.Model.Food;

namespace PetStore.Services
{
    public interface IFoodService
    {
        void Buy(string name, double weight, decimal price, double profit,
            DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(string name, double weight, decimal price, double profit,
            DateTime expirationDate, int brandId, int categoryId);

        void SellFoodToUser(int foodId, int userId);

        bool Exist(int foodId);
    }
}