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
    public class OpskriftsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public OpskriftsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Opskrifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opskrift>>> GetOpskrift()
        {
          if (_context.Opskrift == null)
          {
              return NotFound();
          }
            return await _context.Opskrift.ToListAsync();
        }

        // GET: api/Opskrifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opskrift>> GetOpskrift(int id)
        {
          if (_context.Opskrift == null)
          {
              return NotFound();
          }
            var opskrift = await _context.Opskrift.FindAsync(id);

            if (opskrift == null)
            {
                return NotFound();
            }

            return opskrift;
        }
        // GET: api/Opskrifts/5
        [HttpGet("Øl/{id}")]
        public async Task<ActionResult<List<Opskrift>>> GetOpskriftOnØlId(int id)
        {
          if (_context.Opskrift == null)
          {
              return NotFound();
          }
            var dbØl = _context.Øl.Find(id);
            var opskrift = await _context.Opskrift.Where(o => o.OlId == dbØl.Id).ToListAsync();

            if (opskrift == null)
            {
                return NotFound();
            }

            return opskrift;
        }
        
        // GET: api/Opskrifts/Bryggeri/5
        [HttpGet("Bryggeri/{id}")]
        public async Task<ActionResult<List<Opskrift>>> GetOpskriftOnBryggeriId(int id)
        {
          if (_context.Opskrift == null)
          {
              return NotFound();
          }
            var dbBryggeri = _context.Bryggeri.Find(id);
            var opskrift = await _context.Opskrift.Where(o => o.BryggeriId == dbBryggeri.Id).ToListAsync();

            if (opskrift == null)
            {
                return NotFound();
            }

            return opskrift;
        }

        // PUT: api/Opskrifts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpskrift(int id, Opskrift opskrift)
        {
            if (id != opskrift.Id)
            {
                return BadRequest();
            }

            _context.Entry(opskrift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpskriftExists(id))
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

        // POST: api/Opskrifts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Opskrift>> PostOpskrift(Opskrift opskrift)
        {
          if (_context.Opskrift == null)
          {
              return Problem("Entity set 'NBDBContext.Opskrift'  is null.");
          }
            _context.Opskrift.Add(opskrift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpskrift", new { id = opskrift.Id }, opskrift);
        }

        // DELETE: api/Opskrifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpskrift(int id)
        {
            if (_context.Opskrift == null)
            {
                return NotFound();
            }
            var opskrift = await _context.Opskrift.FindAsync(id);
            if (opskrift == null)
            {
                return NotFound();
            }

            _context.Opskrift.Remove(opskrift);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpskriftExists(int id)
        {
            return (_context.Opskrift?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
