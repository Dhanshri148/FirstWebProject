using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Web.Data;
using LMS.Web.Models;
using LMS.Web.Areas.Books.ViewModels;
using Microsoft.Extensions.Logging;

namespace LMS.Web.Areas.Books.Controllers
{
    [Area("Books")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ApplicationDbContext context,ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Books/Books
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("-------- Retrieve details of the Book along with the Associated Category from the database");

            var viewmodels = await _context.Books
                                                .Include(b => b.Category)
                                                .ToListAsync();

            return View(viewmodels);
        }

        // GET: Books/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            BookViewModel viewModel = new BookViewModel()
            {
                BookId = book.BookId,
                BookTitle=book.BookTitle,
                ImageUrl=book.ImageUrl,
                IsEnabled = book.IsEnabled,
                NumberOfCopies=book.NumberOfCopies,
                CategoryId=book.CategoryId,
                Category = book.Category,

            };

            return View(viewModel);
        }

        // GET: Books/Books/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Books/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,NumberOfCopies,IsEnabled,ImageUrl,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // GET: Books/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);

            var bookViewModel = new BookViewModel()
            {
                BookId = book.BookId,
                BookTitle = book.BookTitle,
                ImageUrl = book.ImageUrl,
                IsEnabled = book.IsEnabled,
                NumberOfCopies = book.NumberOfCopies,
                CategoryId = book.CategoryId,
                Category = book.Category,

            };
            return View(bookViewModel);
        }

        // POST: Books/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,NumberOfCopies,IsEnabled,ImageUrl,CategoryId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // GET: Books/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            var bookViewModel = new BookViewModel()
            {
                BookId = book.BookId,
                BookTitle = book.BookTitle,
                ImageUrl = book.ImageUrl,
                IsEnabled = book.IsEnabled,
                NumberOfCopies = book.NumberOfCopies,
                CategoryId = book.CategoryId,
                Category = book.Category,

            };
            return View(bookViewModel);
        }

        // POST: Books/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
