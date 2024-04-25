using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.DbContexts
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }
        public virtual DbSet<Customers> Customers { get; set; }
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

    }
}