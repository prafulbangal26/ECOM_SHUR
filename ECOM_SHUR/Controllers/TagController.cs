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
    public class TagController : ControllerBase
    {
        private readonly DBSContext _context;

        public TagController(DBSContext context)
        {
            _context = context;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagMaster>>> GetTagMasters()
        {
            return await _context.TagMasters.ToListAsync();
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagMaster>> GetTagMaster(long id)
        {
            var tagMaster = await _context.TagMasters.FindAsync(id);

            if (tagMaster == null)
            {
                return NotFound();
            }

            return tagMaster;
        }

        // PUT: api/Tag/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagMaster(long id, TagMaster tagMaster)
        {
            if (id != tagMaster.TagId)
            {
                return BadRequest();
            }

            _context.Entry(tagMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagMasterExists(id))
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

        // POST: api/Tag
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TagMaster>> PostTagMaster(TagMaster tagMaster)
        {
            _context.TagMasters.Add(tagMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagMaster", new { id = tagMaster.TagId }, tagMaster);
        }

        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TagMaster>> DeleteTagMaster(long id)
        {
            var tagMaster = await _context.TagMasters.FindAsync(id);
            if (tagMaster == null)
            {
                return NotFound();
            }

            _context.TagMasters.Remove(tagMaster);
            await _context.SaveChangesAsync();

            return tagMaster;
        }

        private bool TagMasterExists(long id)
        {
            return _context.TagMasters.Any(e => e.TagId == id);
        }
    }
}
