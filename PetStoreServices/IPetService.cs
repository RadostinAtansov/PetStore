namespace PetStore.Services
{
    using PetStore.Data.Model;
    using PetStore.Services.Model.Pet;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> All(int page = 1);

        void Buypet(Gender gender, DateTime dateTime, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
