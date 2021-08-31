using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECOM_SHUR.DBModel;

namespace ECOM_SHUR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DBSContext _context;

        public CategoryController(DBSContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryMaster>>> GetCategoryMasters()
        {
            return await _context.CategoryMasters.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryMaster>> GetCategoryMaster(long id)
        {
            var categoryMaster = await _context.CategoryMasters.FindAsync(id);

            if (categoryMaster == null)
            {
                return NotFound();
            }

            return categoryMaster;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryMaster(long id, CategoryMaster categoryMaster)
        {
            if (id != categoryMaster.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryMasterExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryMaster>> PostCategoryMaster(CategoryMaster categoryMaster)
        {
            _context.CategoryMasters.Add(categoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryMaster", new { id = categoryMaster.CategoryId }, categoryMaster);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryMaster>> DeleteCategoryMaster(long id)
        {
            var categoryMaster = await _context.CategoryMasters.FindAsync(id);
            if (categoryMaster == null)
            {
                return NotFound();
            }

            _context.CategoryMasters.Remove(categoryMaster);
            await _context.SaveChangesAsync();

            return categoryMaster;
        }

        private bool CategoryMasterExists(long id)
        {
            return _context.CategoryMasters.Any(e => e.CategoryId == id);
        }
    }
}
