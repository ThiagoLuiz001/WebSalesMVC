using MVCSaller.Services;
using Microsoft.AspNetCore.Mvc;
using MVCSaller.Models;
using MVCSaller.Models.ViewModels;
using MVCSaller.Services.Exceptions;

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

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellersService.FindByID(id.Value);
            if (obj == null)
                return NotFound();
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellersService.FindByID(id.Value);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = _sellersService.FindByID(id.Value);
            if (obj == null)
                return NotFound();
            var viewModel = new SellerFormViewModel { Seller = obj, Departments = _departmentService.FindAll() };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellersService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException ex)
            {
                return NotFound();
            }
            catch(DbConCurrrencyException ex)
            {
                return BadRequest();
            }

        }
    }
}
