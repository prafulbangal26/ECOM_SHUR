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
    public class SizeController : ControllerBase
    {
        private readonly DBSContext _context;

        public SizeController(DBSContext context)
        {
            _context = context;
        }

        // GET: api/Size
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeMaster>>> GetSizeMasters()
        {
            return await _context.SizeMasters.ToListAsync();
        }

        // GET: api/Size/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeMaster>> GetSizeMaster(long id)
        {
            var sizeMaster = await _context.SizeMasters.FindAsync(id);

            if (sizeMaster == null)
            {
                return NotFound();
            }

            return sizeMaster;
        }

        // PUT: api/Size/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeMaster(long id, SizeMaster sizeMaster)
        {
            if (id != sizeMaster.SizeId)
            {
                return BadRequest();
            }

            _context.Entry(sizeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeMasterExists(id))
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

        // POST: api/Size
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SizeMaster>> PostSizeMaster(SizeMaster sizeMaster)
        {
            _context.SizeMasters.Add(sizeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeMaster", new { id = sizeMaster.SizeId }, sizeMaster);
        }

        // DELETE: api/Size/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeMaster>> DeleteSizeMaster(long id)
        {
            var sizeMaster = await _context.SizeMasters.FindAsync(id);
            if (sizeMaster == null)
            {
                return NotFound();
            }

            _context.SizeMasters.Remove(sizeMaster);
            await _context.SaveChangesAsync();

            return sizeMaster;
        }

        private bool SizeMasterExists(long id)
        {
            return _context.SizeMasters.Any(e => e.SizeId == id);
        }
    }
}
