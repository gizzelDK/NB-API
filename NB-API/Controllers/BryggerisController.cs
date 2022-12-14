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
    [Route("api/[controller]")]
    [ApiController]
    public class BryggerisController : ControllerBase
    {
        private readonly NBDBContext _context;

        public BryggerisController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Bryggeris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bryggeri>>> GetBryggeri()
        {
          if (_context.Bryggeri == null)
          {
              return NotFound();
          }
            var bryggerier = await _context.Bryggeri.ToListAsync();
            bryggerier.ForEach(b => b.Øl = _context.Øl.Where(x => x.BryggeriId == b.Id).ToList());

            return bryggerier;
        }

        // GET: api/Bryggeris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bryggeri>> GetBryggeri(int id)
        {
          if (_context.Bryggeri == null)
          {
              return NotFound();
          }
            var bryggeri = await _context.Bryggeri.FindAsync(id);

            if (bryggeri == null)
            {
                return NotFound();
            }
            bryggeri.Øl = await _context.Øl.Where(o => o.BryggeriId == id).ToListAsync();


            return bryggeri;
        }

        // PUT: api/Bryggeris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize()]
        public async Task<IActionResult> PutBryggeri(int id, Bryggeri bryggeri)
        {
            if (id != bryggeri.Id)
            {
                return BadRequest();
            }

            _context.Entry(bryggeri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BryggeriExists(id))
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

        // POST: api/Bryggeris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize()]
        public async Task<ActionResult<Bryggeri>> PostBryggeri(Bryggeri bryggeri)
        {
          if (_context.Bryggeri == null)
          {
              return Problem("Entity set 'NBDBContext.Bryggeri'  is null.");
          }
            _context.Bryggeri.Add(bryggeri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBryggeri", new { id = bryggeri.Id }, bryggeri);
        }

        // DELETE: api/Bryggeris/5
        [HttpDelete("{id}"), Authorize()]
        public async Task<IActionResult> DeleteBryggeri(int id)
        {
            try
            {
                if (_context.Bryggeri == null)
                {
                    return NotFound();
                }
                var delbryggeri = await _context.Bryggeri.FindAsync(id);
                if (delbryggeri == null)
                {
                    return NotFound();
                }
                _context.Remove(delbryggeri);

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        private bool BryggeriExists(int id)
        {
            return (_context.Bryggeri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
