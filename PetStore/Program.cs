 namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Services.Implementations;

    public class Program
    {

        public static void Main(string[] args)
        {
            var db = new PetStoreDbContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //db.Database.Migrate();


            /*var userService = new UserService(db)*/
            ;
            //var foodService = new FoodService(db, userService);
            //userService.Register("Pesho", "pesho@abv.bg");
            //foodService.SellFoodToUser(7, 1);
            //foodService.BuyFromDistributor("Cat food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 3);
            //var toyService = new ToyService(db);
            //toyService.BuyFromDistributor("Ball", "Bouncing", 3.50m, 0.3, 1, 3);

        }
    }

}