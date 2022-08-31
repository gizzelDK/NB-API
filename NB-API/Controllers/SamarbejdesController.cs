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
    public class SamarbejdesController : ControllerBase
    {
        private readonly NBDBContext _context;

        public SamarbejdesController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Samarbejdes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samarbejde>>> GetSamarbejde()
        {
          if (_context.Samarbejde == null)
          {
              return NotFound();
          }
            return await _context.Samarbejde.ToListAsync();
        }

        // GET: api/Samarbejdes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samarbejde>> GetSamarbejde(int id)
        {
          if (_context.Samarbejde == null)
          {
              return NotFound();
          }
            var samarbejde = await _context.Samarbejde.FindAsync(id);

            if (samarbejde == null)
            {
                return NotFound();
            }

            return samarbejde;
        }

        // PUT: api/Samarbejdes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamarbejde(int id, Samarbejde samarbejde)
        {
            if (id != samarbejde.Id)
            {
                return BadRequest();
            }

            _context.Entry(samarbejde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamarbejdeExists(id))
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

        // POST: api/Samarbejdes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Samarbejde>> PostSamarbejde(Samarbejde samarbejde)
        {
          if (_context.Samarbejde == null)
          {
              return Problem("Entity set 'NBDBContext.Samarbejde'  is null.");
          }
            _context.Samarbejde.Add(samarbejde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamarbejde", new { id = samarbejde.Id }, samarbejde);
        }

        // DELETE: api/Samarbejdes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamarbejde(int id)
        {
            if (_context.Samarbejde == null)
            {
                return NotFound();
            }
            var samarbejde = await _context.Samarbejde.FindAsync(id);
            if (samarbejde == null)
            {
                return NotFound();
            }

            _context.Samarbejde.Remove(samarbejde);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SamarbejdeExists(int id)
        {
            return (_context.Samarbejde?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
