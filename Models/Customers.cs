using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public class Customers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }
        [MaxLength(30)]
        public string? ContactName { get; set; }
        [MaxLength(30)]
        public string? ContactTitle { get; set; }
        [MaxLength(60)]
        public string? Address { get; set; }
        [MaxLength(15)]
        public string? City { get; set; }
        [MaxLength(15)]
        public string? Region { get; set; }
        [MaxLength(10)]
        public string? PostalCode { get; set; }
        [MaxLength(15)]
        public string? Country { get; set; }
        [MaxLength(24)]
        public string? Phone { get; set; }
        [MaxLength(24)]
        public string? Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
    }
}