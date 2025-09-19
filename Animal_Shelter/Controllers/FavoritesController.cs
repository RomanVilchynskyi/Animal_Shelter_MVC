using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using Animal_Shelter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Animal_Shelter.Extensions;


namespace Animal_Shelter.Controllers;

public class FavoritesController : Controller
{
    private readonly ShelterDbContext ctx;

    public FavoritesController(ShelterDbContext ctx)
    {
        this.ctx = ctx;
    }

    public IActionResult Index()
    {
        var existingIds = HttpContext.Session.Get<List<int>>("FavItems") ?? new List<int>();

        var items = ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .Where(x => existingIds.Contains(x.Id))
                .ToList();

        return View(items);
    }
    public ActionResult Add(int id) 
    {
        var existingIds = HttpContext.Session.Get<List<int>>("FavItems");
        List<int> ids = existingIds ?? new();

        ids.Add(id);

        HttpContext.Session.Set("FavItems", ids);

        return RedirectToAction("Index", "Home");
    }

    public ActionResult Remove(int id)
    {
        var existingIds = HttpContext.Session.Get<List<int>>("FavItems");
        List<int> ids = existingIds ?? new();

        ids.Remove(id);
        HttpContext.Session.Set("FavItems", ids);

        return RedirectToAction("Index");
    }

    public ActionResult Clear()
    {
        HttpContext.Session.Remove("FavItems");

        return RedirectToAction("Index");
    }
}
