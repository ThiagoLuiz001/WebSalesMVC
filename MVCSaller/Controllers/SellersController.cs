using MVCSaller.Services;
using Microsoft.AspNetCore.Mvc;
using MVCSaller.Models;
using MVCSaller.Models.ViewModels;

namespace MVCSaller.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellersService sellersService, DepartmentService departmentService)
        {
            _sellersService = sellersService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            
            return View(_sellersService.FindAll());
        }

        public IActionResult Create()
        {
            var viewModel = new SellerFormViewModel { Departments = _departmentService.FindAll() };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
