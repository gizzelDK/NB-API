using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;

namespace NB_API.Controllers
{
    [Route("api/[controller]"), Authorize()]
    [ApiController]
    public class RapportsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public RapportsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Rapports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rapport>>> GetRapport()
        {
          if (_context.Rapport == null)
          {
              return NotFound();
          }
            return await _context.Rapport.ToListAsync();
        }

        // GET: api/Rapports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rapport>> GetRapport(int id)
        {
          if (_context.Rapport == null)
          {
              return NotFound();
          }
            var rapport = await _context.Rapport.FindAsync(id);

            if (rapport == null)
            {
                return NotFound();
            }

            return rapport;
        }

        // PUT: api/Rapports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRapport(int id, Rapport rapport)
        {
            if (id != rapport.Id)
            {
                return BadRequest();
            }

            _context.Entry(rapport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RapportExists(id))
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

        // POST: api/Rapports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rapport>> PostRapport(Rapport rapport)
        {
          if (_context.Rapport == null)
          {
              return Problem("Entity set 'NBDBContext.Rapport'  is null.");
          }
            _context.Rapport.Add(rapport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRapport", new { id = rapport.Id }, rapport);
        }

        // DELETE: api/Rapports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRapport(int id)
        {
            if (_context.Rapport == null)
            {
                return NotFound();
            }
            var rapport = await _context.Rapport.FindAsync(id);
            if (rapport == null)
            {
                return NotFound();
            }

            _context.Rapport.Remove(rapport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RapportExists(int id)
        {
            return (_context.Rapport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
