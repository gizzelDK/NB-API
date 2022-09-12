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
    public class KommentarsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public KommentarsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Kommentars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kommentar>>> GetKommentar()
        {
          if (_context.Kommentar == null)
          {
              return NotFound();
          }
            return await _context.Kommentar.ToListAsync();
        }

        // GET: api/Kommentars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kommentar>> GetKommentar(int id)
        {
          if (_context.Kommentar == null)
          {
              return NotFound();
          }
            var kommentar = await _context.Kommentar.FindAsync(id);

            if (kommentar == null)
            {
                return NotFound();
            }

            return kommentar;
        }

        // PUT: api/Kommentars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKommentar(int id, Kommentar kommentar)
        {
            if (id != kommentar.Id)
            {
                return BadRequest();
            }

            _context.Entry(kommentar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KommentarExists(id))
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

        // POST: api/Kommentars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kommentar>> PostKommentar(Kommentar kommentar)
        {
            try
            {
                _context.Kommentar.Add(kommentar);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetKommentar", new { id = kommentar.Id }, kommentar);
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }

        // DELETE: api/Kommentars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKommentar(int id)
        {
            if (_context.Kommentar == null)
            {
                return NotFound();
            }
            var kommentar = await _context.Kommentar.FindAsync(id);
            if (kommentar == null)
            {
                return NotFound();
            }

            _context.Kommentar.Remove(kommentar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KommentarExists(int id)
        {
            return (_context.Kommentar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
