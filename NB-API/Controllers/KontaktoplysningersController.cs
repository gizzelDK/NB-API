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
    public class KontaktoplysningersController : ControllerBase
    {
        private readonly NBDBContext _context;

        public KontaktoplysningersController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Kontaktoplysningers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kontaktoplysninger>>> GetKontaktoplysninger()
        {
          if (_context.Kontaktoplysninger == null)
          {
              return NotFound();
          }
            return await _context.Kontaktoplysninger.ToListAsync();
        }

        // GET: api/Kontaktoplysningers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kontaktoplysninger>> GetKontaktoplysninger(int id)
        {
          if (_context.Kontaktoplysninger == null)
          {
              return NotFound();
          }
            var kontaktoplysninger = await _context.Kontaktoplysninger.FindAsync(id);

            if (kontaktoplysninger == null)
            {
                return NotFound();
            }

            return kontaktoplysninger;
        }

        // PUT: api/Kontaktoplysningers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontaktoplysninger(int id, Kontaktoplysninger kontaktoplysninger)
        {
            if (id != kontaktoplysninger.Id)
            {
                return BadRequest();
            }

            _context.Entry(kontaktoplysninger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontaktoplysningerExists(id))
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

        // POST: api/Kontaktoplysningers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kontaktoplysninger>> PostKontaktoplysninger(Kontaktoplysninger kontaktoplysninger)
        {
          if (_context.Kontaktoplysninger == null)
          {
              return Problem("Entity set 'NBDBContext.Kontaktoplysninger'  is null.");
          }
            _context.Kontaktoplysninger.Add(kontaktoplysninger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontaktoplysninger", new { id = kontaktoplysninger.Id }, kontaktoplysninger);
        }

        // DELETE: api/Kontaktoplysningers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKontaktoplysninger(int id)
        {
            if (_context.Kontaktoplysninger == null)
            {
                return NotFound();
            }
            var kontaktoplysninger = await _context.Kontaktoplysninger.FindAsync(id);
            if (kontaktoplysninger == null)
            {
                return NotFound();
            }

            _context.Kontaktoplysninger.Remove(kontaktoplysninger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KontaktoplysningerExists(int id)
        {
            return (_context.Kontaktoplysninger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
