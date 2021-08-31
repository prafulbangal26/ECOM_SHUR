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
    public class ColorController : ControllerBase
    {
        private readonly DBSContext _context;

        public ColorController(DBSContext context)
        {
            _context = context;
        }

        // GET: api/Color
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorMaster>>> GetColorMasters()
        {
            return await _context.ColorMasters.ToListAsync();
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorMaster>> GetColorMaster(long id)
        {
            var colorMaster = await _context.ColorMasters.FindAsync(id);

            if (colorMaster == null)
            {
                return NotFound();
            }

            return colorMaster;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorMaster(long id, ColorMaster colorMaster)
        {
            if (id != colorMaster.ColorId)
            {
                return BadRequest();
            }

            _context.Entry(colorMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorMasterExists(id))
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

        // POST: api/Color
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ColorMaster>> PostColorMaster(ColorMaster colorMaster)
        {
            _context.ColorMasters.Add(colorMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorMaster", new { id = colorMaster.ColorId }, colorMaster);
        }

        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColorMaster>> DeleteColorMaster(long id)
        {
            var colorMaster = await _context.ColorMasters.FindAsync(id);
            if (colorMaster == null)
            {
                return NotFound();
            }

            _context.ColorMasters.Remove(colorMaster);
            await _context.SaveChangesAsync();

            return colorMaster;
        }

        private bool ColorMasterExists(long id)
        {
            return _context.ColorMasters.Any(e => e.ColorId == id);
        }
    }
}
