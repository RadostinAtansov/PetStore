using System;

namespace PetStore.Services.Model.Food
{
    public class AddingFoodServiceModel
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public double Profit { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public int CategiryId { get; set; }
    }
}
