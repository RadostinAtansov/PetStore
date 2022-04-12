 namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Data.Model;
    using PetStore.Services.Implementations;

    public class Program
    {

        public static void Main(string[] args)
        {
            var data = new PetStoreDbContext();

            for (int i = 0; i < 10; i++)
            {
                var breed = new Breed
                {
                    Name = "Breed" + i,
                };
                data.Breeds.Add(breed);
            }
            data.SaveChanges();

            for (int i = 0; i < 30; i++)
            {
                var category = new Category
                {
                    Name = "Category" + i,
                    Description = "Category desciption" + i,
                };
                data.Categories.Add(category);
            }
            data.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                var breed = data
                    .Breeds
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => c.Id)
                    .FirstOrDefault();

                var category = data
                    .Categories
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => c.Id)
                    .FirstOrDefault();

                var pet = new Pet
                {
                    Name = "Gosho" + i,
                    DateOfBird = DateTime.UtcNow.AddDays(-60 + i),
                    Price = 50 + i,
                    Gender = (Gender)(i % 2),
                    Description = "Some randem description" + i,
                    CategoryId = category,
                    BreedId = breed,
                };
                data.Pets.Add(pet);
            }
            data.SaveChanges();

        }
    }

}