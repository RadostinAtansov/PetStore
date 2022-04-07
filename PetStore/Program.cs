namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Data;

   public class Program
    {

        public static void Main(string[] args)
        {
            var db = new PetStoreDbContext();
            db.Database.Migrate();
        }
    }

}