using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;

namespace NB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ØlTagsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public ØlTagsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/ØlTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ØlTags>>> GetØlTags()
        {
          if (_context.ØlTags == null)
          {
              return NotFound();
          }
            return await _context.ØlTags.ToListAsync();
        }

        // GET: api/ØlTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ØlTags>> GetØlTags(int id)
        {
          if (_context.ØlTags == null)
          {
              return NotFound();
          }
            var ølTags = await _context.ØlTags.FindAsync(id);

            if (ølTags == null)
            {
                return NotFound();
            }

            return ølTags;
        }

        // PUT: api/ØlTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutØlTags(int id, ØlTags ølTags)
        {
            if (id != ølTags.Id)
            {
                return BadRequest();
            }

            _context.Entry(ølTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ØlTagsExists(id))
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

        // POST: api/ØlTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ØlTags>> PostØlTags(ØlTags ølTags)
        {
            var tags = await _context.ØlTags.Where(o => o.TagId == ølTags.TagId && o.ØlId == ølTags.ØlId).ToListAsync();
            if(ølTags.ØlId == null || ølTags.TagId == null)
            {
                return BadRequest("mangler enten ølId eller tagId");
            }
            if(tags != null)
            {
                return BadRequest("Tag findes allerede:" + tags[0].Id);
            }

            _context.ØlTags.Add(ølTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetØlTags", new { id = ølTags.Id }, ølTags);
        }

        // DELETE: api/ØlTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteØlTags(int id)
        {
            if (_context.ØlTags == null)
            {
                return NotFound();
            }
            var ølTags = await _context.ØlTags.FindAsync(id);
            if (ølTags == null)
            {
                return NotFound();
            }

            _context.ØlTags.Remove(ølTags);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ØlTagsExists(int id)
        {
            return (_context.ØlTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
