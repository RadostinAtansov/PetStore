using PetStore.Data.Model;

namespace PetStore.Services
{
    public interface IPetService
    {
        void Buypet(Gender gender, DateTime dateTime, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
