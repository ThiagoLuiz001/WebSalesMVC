using MVCSaller.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCSaller.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;

        public SellersController(SellersService sellersService)
        {
            _sellersService = sellersService;
        }
        public IActionResult Index()
        {
            
            return View(_sellersService.FindAll());
        }
    }
}
