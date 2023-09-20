using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAll();
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.AddEntry(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool customerExists = await _customerRepository.Exists(customer.CustomerId);

                if (!customerExists)
                {
                    return NotFound();
                }

                try
                {
                    await _customerRepository.UpdateEntry(customer);
                }
                catch (Exception)
                {
                    if (!await _customerRepository.Exists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool customerExists = await _customerRepository.Exists(id);

            if (!customerExists)
            {
                return NotFound();
            }

            await _customerRepository.DeleteEntry(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
