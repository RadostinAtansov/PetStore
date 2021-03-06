using PetStore.Data;
using PetStore.Data.Model;
using PetStore.Services.Model.Pet;

namespace PetStore.Services.Implementations
{
    public class PetService : IPetService
    {
        private const int petsPageSize = 25;

        private readonly PetStoreDbContext data;
        private readonly IBreedService breedService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        public PetService(PetStoreDbContext data, IBreedService breedService, ICategoryService categoryService, IUserService userService)
        {
            this.data = data;
            this.breedService = breedService;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        public IEnumerable<PetListingServiceModel> All(int page = 1)
            => this.data
            .Pets
            .Skip((page - 1) * petsPageSize)
            .Take(petsPageSize)
            .Select(p => new PetListingServiceModel
            {
                Id = p.Id,
                Price = p.Price,
                Breed = p.Breed.Name,
                Category = p.Category.Name
            })
            .ToList();

        public void Buypet(Gender gender, DateTime dateTime, decimal price, string description, int breedId, int categoryId, DateTime dateOfBird)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price of the pet cannot be less than zero");
            }

            if (!this.breedService.Exists(breedId))
            {
                throw new ArgumentException("There is no such breed with given id in database");
            }

            if (!this.categoryService.Exists(categoryId))
            {
                throw new ArgumentException("There is no such categoty with given id in database");
            }

            var pet = new Pet() 
            {
                Gender = gender,
                DateOfBird = dateOfBird,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId,
            };
            this.data.Pets.Add(pet);
            this.data.SaveChanges();
        }

        public void Buypet(Gender gender, DateTime dateTime, decimal price, string description, int breedId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int petId)
        {
            return this.data.Pets.Any(p => p.Id == petId);
        }

        public void SellPet(int petId, int userId)
        {
            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such pet in database");
            }
            if (!this.Exists(petId))
            {
                throw new ArgumentException("There is no such pet in database");
            }

            var pet = this.data.Pets
                .First(p => p.Id == petId);

            var order = new Order() 
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };
            this.data.Orders.Add(order);
            pet.Order = order;

            this.data.SaveChanges();
        }
    }
}
