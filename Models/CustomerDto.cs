using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CustomerDto
    {

        public string CustomerId { get; set; }

        public string CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }

    }
}