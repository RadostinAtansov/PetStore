namespace PetStore.Services
{
    using Model.Brand;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);

    }
}
