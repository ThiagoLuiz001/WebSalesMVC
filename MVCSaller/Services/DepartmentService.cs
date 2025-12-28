using MVCSaller.Data;
using MVCSaller.Models;

namespace MVCSaller.Services
{
    public class DepartmentService
    {
        private readonly MVCSallerContext _context;

        public DepartmentService(MVCSallerContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x=> x.Name).ToList();
        }
    }
}
