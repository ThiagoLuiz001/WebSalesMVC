using Microsoft.AspNetCore.Mvc;

namespace MVCSaller.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
