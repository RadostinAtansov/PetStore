
namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services.Model.Pet;
    using PetStore.Web.Models.Pets;
    using Services;

    public class PetsController : Controller
    {
        private readonly IPetService pets;

        public PetsController(IPetService pets)
            => this.pets = pets;

        public IActionResult All(int page = 1)
        {
            var pets = this.pets.All(page);

            var model = new AllPetsViewModel
            {
                Pets = pets,
                CurrentPage = page
            };

            return View(model);
        }
    }
}