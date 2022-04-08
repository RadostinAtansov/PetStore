using PetStore.Data;
using PetStore.Data.Model;

namespace PetStore.Services.Implementations
{
    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Breed name cannot be null or white space!");
            }

            var breed = new Breed()
            {
                Name = name,
            };

            this.data.Breeds.Add(breed);
            this.data.SaveChanges();
        }

        public bool Exists(int breedId)
        {
            return this.data.Breeds.Any(b => b.Id == breedId);
        }
    }
}
