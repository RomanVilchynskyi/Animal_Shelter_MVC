using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using Animal_Shelter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Animal_Shelter.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Animal_Shelter.Interfaces;


namespace Animal_Shelter.Controllers;

public class FavoritesController : Controller
{
    private readonly ShelterDbContext ctx;
    private readonly IFavService favService;

    public FavoritesController(ShelterDbContext ctx, IFavService favService)
    {
        this.ctx = ctx;
        this.favService = favService;
    }

    public IActionResult Index()
    {
        var items = favService.GetAnimals();

        return View(items);
    }
    public ActionResult Add(int id) 
    {
        favService.Add(id);

        return RedirectToAction("Index", "Home");
    }

    public ActionResult Remove(int id)
    {
        favService.Remove(id);

        return RedirectToAction("Index");
    }

    public ActionResult Clear()
    {
        favService.Clear();

        return RedirectToAction("Index");
    }
}
