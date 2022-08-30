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
    public class ExerciseCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExerciseCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseCategory>>> GetExerciseCategories()
        {
            return await _context.ExerciseCategories.ToListAsync();
        }

        // GET: api/ExerciseCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseCategory>> GetExerciseCategory(int id)
        {
            var exerciseCategory = await _context.ExerciseCategories.FindAsync(id);

            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return exerciseCategory;
        }

        // PUT: api/ExerciseCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseCategory(int id, ExerciseCategory exerciseCategory)
        {
            if (id != exerciseCategory.ExerciseCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(exerciseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseCategoryExists(id))
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

        // POST: api/ExerciseCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExerciseCategory>> PostExerciseCategory(ExerciseCategory exerciseCategory)
        {
            _context.ExerciseCategories.Add(exerciseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciseCategory", new { id = exerciseCategory.ExerciseCategoryId }, exerciseCategory);
        }

        // DELETE: api/ExerciseCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExerciseCategory>> DeleteExerciseCategory(int id)
        {
            var exerciseCategory = await _context.ExerciseCategories.FindAsync(id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }

            _context.ExerciseCategories.Remove(exerciseCategory);
            await _context.SaveChangesAsync();

            return exerciseCategory;
        }

        private bool ExerciseCategoryExists(int id)
        {
            return _context.ExerciseCategories.Any(e => e.ExerciseCategoryId == id);
        }
    }
}
