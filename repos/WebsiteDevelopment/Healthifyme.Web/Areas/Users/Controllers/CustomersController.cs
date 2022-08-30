using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Healthifyme.Web.Data;
using Healthifyme.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Healthifyme.Web.Areas.Users.Controllers
{
    [Area("Users")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customers.Include(c => c.Dietition).Include(c => c.Payment);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Customers.Include(c => c.Dietition).Include(c => c.Payment);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Users/Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Dietition)
                .Include(c => c.Payment)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        // GET: Users/Customers/Create
        public IActionResult Create()
        {
            ViewData["DietitionId"] = new SelectList(_context.Dietitions, "DietitionId", "DietitionName");
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentType");
            return View();
        }

        // POST: Users/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Address,ContactNumber,DietitionId,PaymentId,PaymentStatus")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietitionId"] = new SelectList(_context.Dietitions, "DietitionId", "DietitionName", customer.DietitionId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentType", customer.PaymentId);
            return View(customer);
        }

        // GET: Users/Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["DietitionId"] = new SelectList(_context.Dietitions, "DietitionId", "DietitionName", customer.DietitionId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentType", customer.PaymentId);
            return View(customer);
        }

        // POST: Users/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,Address,ContactNumber,DietitionId,PaymentId,PaymentStatus")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["DietitionId"] = new SelectList(_context.Dietitions, "DietitionId", "DietitionName", customer.DietitionId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentType", customer.PaymentId);
            return View(customer);
        }

        // GET: Users/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Dietition)
                .Include(c => c.Payment)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Users/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
