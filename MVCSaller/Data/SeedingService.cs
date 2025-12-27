using MVCSaller.Models;
using MVCSaller.Models.Enums;

namespace MVCSaller.Data
{
    public class SeedingService
    {
        private MVCSallerContext _context;

        public SeedingService(MVCSallerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() ||
               _context.Seller.Any() ||
               _context.SalesRecord.Any())
                return; // DB has been seeded
            var departments = SeedDepartments();
            var sellers = SeedSellers(departments);
            var salesRecords = SeedSalesRecords(sellers);

            _context.Department.AddRange(departments);
            _context.Seller.AddRange(sellers);
            _context.SalesRecord.AddRange(salesRecords);

            _context.SaveChanges();


        }

        private List<Department> SeedDepartments()
        {
            return new List<Department>
            {
                new Department (1,"Computers"),
                new Department  (2,"Electronics"),
                new Department (3, "Fashion"),
                new Department (4,"Books")
            };
        }

        private List<Seller> SeedSellers(List<Department>dep)
        {
            return new List<Seller>
            {
                new Seller(1,"Bob Brown", "bob@gmail.com", 1000, new DateTime(1998,4,21),dep[0]),
                new Seller(2, "Anna Shei", "annashei@outlook.com", (decimal)1200.00, new DateTime(1997,5,15),dep[1]),
                new Seller(3, "Emstein Knwostein", "knwostein@hotmail.com", (decimal)1300.94, new DateTime(1995,11,30),dep[2]),
                new Seller(4, "Frederic Armstrong", "arms@gmail.com", (decimal)2334.21, new DateTime(1994,7,19),dep[3])
            };
        }

        private List<SalesRecord> SeedSalesRecords(List<Seller> sellers)
        {
            return new List<SalesRecord>
            {
                new SalesRecord(1, new DateTime(2023,09,25), (decimal)1100.00, SalesStatus.Billed, sellers[0]),
                new SalesRecord(2, new DateTime(2023,09,26), (decimal)1500.00, SalesStatus.Billed, sellers[1]),
                new SalesRecord(3, new DateTime(2023,09,27), (decimal)900.00, SalesStatus.Canceled, sellers[2]),
                new SalesRecord(4, new DateTime(2023,09,28), (decimal)2000.00, SalesStatus.Pending, sellers[3])
            };
        }
    }
}
