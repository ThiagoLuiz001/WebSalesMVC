using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCSaller.Models;

namespace MVCSaller.Data
{
    public class MVCSallerContext : DbContext
    {
        public MVCSallerContext (DbContextOptions<MVCSallerContext> options)
            : base(options)
        {
        }

        public DbSet<MVCSaller.Models.Department> Department { get; set; } = default!;
    }
}
