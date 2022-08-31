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
    public class BrugersController : ControllerBase
    {
        private readonly NBDBContext _context;

        public BrugersController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Brugers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bruger>>> GetBruger()
        {
          if (_context.Bruger == null)
          {
              return NotFound();
          }
            return await _context.Bruger.ToListAsync();
        }

        // GET: api/Brugers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bruger>> GetBruger(int id)
        {
          if (_context.Bruger == null)
          {
              return NotFound();
          }
            var bruger = await _context.Bruger.FindAsync(id);

            if (bruger == null)
            {
                return NotFound();
            }

            return bruger;
        }

        // PUT: api/Brugers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
        {
            if (id != bruger.Id)
            {
                return BadRequest();
            }

            _context.Entry(bruger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrugerExists(id))
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

        // POST: api/Brugers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bruger>> PostBruger(Bruger bruger)
        {
          if (_context.Bruger == null)
          {
              return Problem("Entity set 'NBDBContext.Bruger'  is null.");
          }
            _context.Bruger.Add(bruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruger", new { id = bruger.Id }, bruger);
        }

        // DELETE: api/Brugers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(int id)
        {
            if (_context.Bruger == null)
            {
                return NotFound();
            }
            var bruger = await _context.Bruger.FindAsync(id);
            if (bruger == null)
            {
                return NotFound();
            }

            _context.Bruger.Remove(bruger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrugerExists(int id)
        {
            return (_context.Bruger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
