using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Services;
using AutoMapper;
using Northwind.Models;

namespace Northwind.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ILogger<CustomerController> logger,
                                  CustomerRepository customerRepository,
                                  IMapper mapper)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("Index", Name = "Index")]
        public async Task<IActionResult> Index()
        {
            var customer = await _customerRepository.GetCustomersAsync();
            return View(_mapper.Map<IEnumerable<CustomerDto>>(customer));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("Update", Name = "Update")]
        public async Task<IActionResult> Update(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpDelete("Delete", Name = "Delete")]
        public IActionResult Delete(string id)
        {
            return View();
        }

        [HttpGet("Get", Name = "Get")]
        public IActionResult Get(string id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}