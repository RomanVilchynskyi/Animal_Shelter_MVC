
using Animal_Shelter.Data;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Shelter.Controllers
{
    public class QuestionnaireController:Controller
    {
        public IActionResult Index()
        {
            ShelterDbContext ctx = new();
            var model = ctx.AnimalQuestionnaires.ToList();

            return View(model);
        }
    }
}
