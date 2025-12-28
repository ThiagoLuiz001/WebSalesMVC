using MVCSaller.Data;
using MVCSaller.Models;

namespace MVCSaller.Services
{
    public class SellersService
    {
        private readonly MVCSallerContext _context;

        public SellersService(MVCSallerContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
