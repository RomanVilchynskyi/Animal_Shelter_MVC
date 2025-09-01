
using Animal_Shelter.Data;
using Animal_Shelter.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SpeciesList = new SelectList(ctx.Species, "Id", "Name");
            ViewBag.BreedList = new SelectList(ctx.Breeds, "Id", "Name");
            ViewBag.GenderList = new SelectList(ctx.Gender, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnimalQuestionnaire animal)
        {

            if (!ModelState.IsValid)
            {
                // Якщо є валідація — перезаповнюємо списки
                ViewBag.SpeciesList = new SelectList(ctx.Species, "Id", "Name");
                ViewBag.BreedList = new SelectList(ctx.Breeds, "Id", "Name");
                ViewBag.GenderList = new SelectList(ctx.Gender, "Id", "Name");
                return View(animal);
            }

            ctx.AnimalQuestionnaires.Add(animal);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .FirstOrDefault(a => a.Id == id);

            if (animal == null) return NotFound();

            ViewBag.SpeciesList = new SelectList(ctx.Species, "Id", "Name", animal.SpeciesId);
            ViewBag.BreedList = new SelectList(ctx.Breeds, "Id", "Name", animal.BreedId);
            ViewBag.GenderList = new SelectList(ctx.Gender, "Id", "Name", animal.GenderId);

            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(AnimalQuestionnaire animal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SpeciesList = new SelectList(ctx.Species, "Id", "Name", animal.SpeciesId);
                ViewBag.BreedList = new SelectList(ctx.Breeds, "Id", "Name", animal.BreedId);
                ViewBag.GenderList = new SelectList(ctx.Gender, "Id", "Name", animal.GenderId);

                return View(animal);
            }

            ctx.AnimalQuestionnaires.Update(animal);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var animal = ctx.AnimalQuestionnaires.Find(id);
            if (animal == null) return NotFound();

            ctx.AnimalQuestionnaires.Remove(animal);
            ctx.SaveChanges(); // submit changes to DB

            return RedirectToAction("Index");
        }
    }
}
