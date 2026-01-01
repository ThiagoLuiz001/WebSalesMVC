using MVCSaller.Data;
using MVCSaller.Models;
using Microsoft.EntityFrameworkCore;

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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller? FindByID(int id)
        {
            return _context.Seller.Include(x=>x.Department).FirstOrDefault(x=> x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            if (obj != null)
            {
                _context.Seller.Remove(obj);
                _context.SaveChanges();
            }
        }   
    }
}
