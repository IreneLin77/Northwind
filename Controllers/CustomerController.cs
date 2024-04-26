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
        [HttpGet("Create", Name = "Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create", Name = "Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateDto customer)
        {
            var exist = await _customerRepository.CustomerExistAsync(customer.CustomerId);
            if (exist)
            {
                ModelState.AddModelError("CustomerId", "Customer ID already exists.");
                return View(customer);
            }
            if (ModelState.IsValid)
            {
                var customerEntity = _mapper.Map<Customers>(customer);
                await _customerRepository.AddCustomersAsync(customerEntity);
                await _customerRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet("Update", Name = "Update")]
        public async Task<IActionResult> Update(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CustomerUpdateDto>(customer));
        }

        [HttpPost("Update", Name = "Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CustomerUpdateDto customer)
        {
            if (ModelState.IsValid)
            {
                var customerEntity = await _customerRepository.GetCustomerByIdAsync(customer.CustomerId);
                if (customerEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(customer, customerEntity);
                await _customerRepository.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpDelete("Delete", Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var customerEntity = await _customerRepository.FindCustomerAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            _customerRepository.DeleteCustomer(customerEntity);
            await _customerRepository.SaveChangesAsync();

            return Json(new { ok = true });
        }

        [HttpGet("Details", Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<CustomerDetailDto>(customer));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}