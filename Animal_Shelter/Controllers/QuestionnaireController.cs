
using Animal_Shelter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Controllers
{
    public class QuestionnaireController:Controller
    {
        public IActionResult Index()
        {
            ShelterDbContext ctx = new();
            var model = ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .ToList();

            return View(model);
        }
    }
}
