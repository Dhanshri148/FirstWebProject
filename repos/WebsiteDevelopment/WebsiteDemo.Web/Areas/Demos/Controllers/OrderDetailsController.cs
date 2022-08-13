using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteDemo.Web.Data;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Demos/OrderDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDetails.Include(o => o.Food).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Demos/OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Food)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: Demos/OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName");
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderName");
            return View();
        }

        // POST: Demos/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailID,TableNumber,Quantity,FoodId,OrderId,CustomerId")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", orderDetail.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderName", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: Demos/OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", orderDetail.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderName", orderDetail.OrderId);
            return View(orderDetail);
        }

        // POST: Demos/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,TableNumber,Quantity,FoodId,OrderId,CustomerId")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailID))
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
            //ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["FoodId"] = new SelectList(_context.Foods, "FoodId", "FoodName", orderDetail.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderName", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: Demos/OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Food)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: Demos/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}
