using MVCSaller.Data;
using MVCSaller.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCSaller.Services
{
    public class SalesRecordService
    {
        private readonly MVCSallerContext _context;

        public SalesRecordService(MVCSallerContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x=>x.Seller.Department).OrderByDescending(x=>x.Date).ToListAsync();

        }

        public async Task<List<IGrouping<Department,SalesRecord>>>FindByDateGroupingAsync (DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).GroupBy(x=>x.Seller.Department).ToListAsync();

        }
    }
}
