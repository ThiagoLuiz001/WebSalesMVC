using Microsoft.AspNetCore.Mvc;
using MVCSaller.Models;

namespace MVCSaller.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "Eletronics" });
            departments.Add(new Department { Id = 2, Name = "Fashion" });

            return View(departments);
        }
    }
}
