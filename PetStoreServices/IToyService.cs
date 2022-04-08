using PetStore.Services.Model.Toy;

namespace PetStore.Services
{
    public interface IToyService
    {
        void BuyFromDistributor(string name, string description, decimal destributorPrice, double profit, int brandId, int categoryId);

        void BuyFromDistributor(AddingToyServiceModel model);

        void SellToyToUser(int toyId, int userId);

        bool Exists(int toyId);
    }
}
