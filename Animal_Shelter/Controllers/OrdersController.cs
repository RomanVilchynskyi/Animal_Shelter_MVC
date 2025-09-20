using Animal_Shelter.Data;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Shelter.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShelterDbContext ctx;
        public OrdersController(ShelterDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            var orders = ctx.Orders.ToList();
            return View(orders);
        }
    }
}
