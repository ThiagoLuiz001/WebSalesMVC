using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x=> x.Name).ToListAsync();
        }
    }
}
