using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using Animal_Shelter.Data;
using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Controllers;

public class HomeController : Controller
{
    private readonly ShelterDbContext ctx;

    public HomeController(ShelterDbContext ctx)
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
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
