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
    public class ØlController : ControllerBase
    {
        private readonly NBDBContext _context;

        public ØlController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Øl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Øl>>> GetØl()
        {
          if (_context.Øl == null)
          {
              return NotFound();
          }
            return await _context.Øl.ToListAsync();
        }

        // GET: api/Øl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Øl>> GetØl(int id)
        {
          if (_context.Øl == null)
          {
              return NotFound();
          }
            var øl = await _context.Øl.FindAsync(id);

            if (øl == null)
            {
                return NotFound();
            }

            return øl;
        }

        // PUT: api/Øl/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutØl(int id, Øl øl)
        {
            if (id != øl.Id)
            {
                return BadRequest();
            }

            _context.Entry(øl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ØlExists(id))
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

        // POST: api/Øl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Øl>> PostØl(Øl øl)
        {
          if (_context.Øl == null)
          {
              return Problem("Entity set 'NBDBContext.Øl'  is null.");
          }
            _context.Øl.Add(øl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetØl", new { id = øl.Id }, øl);
        }

        // DELETE: api/Øl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteØl(int id)
        {
            if (_context.Øl == null)
            {
                return NotFound();
            }
            var øl = await _context.Øl.FindAsync(id);
            if (øl == null)
            {
                return NotFound();
            }

            _context.Øl.Remove(øl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ØlExists(int id)
        {
            return (_context.Øl?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
