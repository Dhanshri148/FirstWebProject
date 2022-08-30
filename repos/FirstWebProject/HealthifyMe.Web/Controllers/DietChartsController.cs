using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthifyMe.Web.Data;
using HealthifyMe.Web.Models;

namespace HealthifyMe.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietChartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DietChartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DietCharts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietChart>>> GetDietCharts()
        {
            return await _context.DietCharts.ToListAsync();
        }

        // GET: api/DietCharts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DietChart>> GetDietChart(int id)
        {
            var dietChart = await _context.DietCharts.FindAsync(id);

            if (dietChart == null)
            {
                return NotFound();
            }

            return dietChart;
        }

        // PUT: api/DietCharts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDietChart(int id, DietChart dietChart)
        {
            if (id != dietChart.DietChartId)
            {
                return BadRequest();
            }

            _context.Entry(dietChart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietChartExists(id))
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

        // POST: api/DietCharts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DietChart>> PostDietChart(DietChart dietChart)
        {
            _context.DietCharts.Add(dietChart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDietChart", new { id = dietChart.DietChartId }, dietChart);
        }

        // DELETE: api/DietCharts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DietChart>> DeleteDietChart(int id)
        {
            var dietChart = await _context.DietCharts.FindAsync(id);
            if (dietChart == null)
            {
                return NotFound();
            }

            _context.DietCharts.Remove(dietChart);
            await _context.SaveChangesAsync();

            return dietChart;
        }

        private bool DietChartExists(int id)
        {
            return _context.DietCharts.Any(e => e.DietChartId == id);
        }
    }
}
