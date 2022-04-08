using PetStore.Data;

namespace PetStore.Services.Implementations
{
    public class CateogryService : ICategoryService
    {
        private readonly PetStoreDbContext data;

        public CateogryService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public bool Exists(int categoryId)
        {
            return this.data.Categories
                .Any(c => c.Id == categoryId);
        }
    }
}
