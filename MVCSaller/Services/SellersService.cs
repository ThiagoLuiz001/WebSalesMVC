using MVCSaller.Data;
using MVCSaller.Services.Exceptions;
using MVCSaller.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MVCSaller.Services
{
    public class SellersService
    {
        private readonly MVCSallerContext _context;

        public SellersService(MVCSallerContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller?> FindByIDAsync(int id)
        {
            return await _context.Seller.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                if (obj != null)
                {
                    _context.Seller.Remove(obj);
                    await _context.SaveChangesAsync();
                }
            }
            catch(DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }

        }

        public async Task UpdateAsync(Seller obj)
        {
            var hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConCurrrencyException(ex.Message);
            }
        }


    }
}
