using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using Northwind.DbContexts;


namespace Northwind.Services
{
    public class CustomerRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCustomersAsync(Customers customer)
        {
            _context.Add(customer);
        }
        public async Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }
        public async Task<Customers?> FindCustomerAsync(string id)
        {
            return await _context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<bool> CustomerExistAsync(string id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == id);
        }

        public void DeleteCustomer(Customers customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}