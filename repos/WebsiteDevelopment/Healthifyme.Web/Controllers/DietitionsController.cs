using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Healthifyme.Web.Data;
using Healthifyme.Web.Models;

namespace Healthifyme.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DietitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dietitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dietition>>> GetDietitions()
        {
            return await _context.Dietitions.ToListAsync();
        }

        // GET: api/Dietitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dietition>> GetDietition(int id)
        {
            var dietition = await _context.Dietitions.FindAsync(id);

            if (dietition == null)
            {
                return NotFound();
            }

            return dietition;
        }

        // PUT: api/Dietitions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDietition(int id, Dietition dietition)
        {
            if (id != dietition.DietitionId)
            {
                return BadRequest();
            }

            _context.Entry(dietition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dietitions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dietition>> PostDietition(Dietition dietition)
        {
            _context.Dietitions.Add(dietition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDietition", new { id = dietition.DietitionId }, dietition);
        }

        // DELETE: api/Dietitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dietition>> DeleteDietition(int id)
        {
            var dietition = await _context.Dietitions.FindAsync(id);
            if (dietition == null)
            {
                return NotFound();
            }

            _context.Dietitions.Remove(dietition);
            await _context.SaveChangesAsync();

            return dietition;
        }

        private bool DietitionExists(int id)
        {
            return _context.Dietitions.Any(e => e.DietitionId == id);
        }
    }
}
