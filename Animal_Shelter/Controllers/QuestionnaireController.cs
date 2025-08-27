
using Animal_Shelter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Controllers
{
    public class QuestionnaireController:Controller
    {
        private readonly ShelterDbContext ctx;
        public QuestionnaireController(ShelterDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            var model = ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .ToList();

            return View(model);
        }
        public IActionResult DetailInfo(int id)
        {
            var animal = ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .FirstOrDefault(x => x.Id == id);
            if (animal == null)
                return NotFound();

            return View(animal);
        }
    }
}
