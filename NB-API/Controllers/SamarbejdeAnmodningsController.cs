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
    public class SamarbejdeAnmodningsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public SamarbejdeAnmodningsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Brugere
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SamarbejdeAnmodning>>> GetSamarbejdeAnmodning()
        {
            return await _context.SamarbejdeAnmodning.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SamarbejdeAnmodning>> GetSamarbejdeAnmodning(int id)
        {
            var samarbejdeAnmodning = await _context.SamarbejdeAnmodning.FindAsync(id);

            if (samarbejdeAnmodning == null)
            {
                return NotFound();
            }

            return samarbejdeAnmodning;
        }

        // PUT: api/Brugere/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamarbejdeAnmodning(int id, SamarbejdeAnmodning samarbejdeAnmodning)
        {
            if (id != samarbejdeAnmodning.Id)
            {
                return BadRequest();
            }

            _context.Entry(samarbejdeAnmodning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamarbejdeAnmodningExists(id))
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

        // POST: api/Brugere
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SamarbejdeAnmodning>> PostSamarbejdeAnmodning(SamarbejdeAnmodning samarbejdeAnmodning)
        {
            samarbejdeAnmodning = new SamarbejdeAnmodning
            {
                BryggeriId1 = samarbejdeAnmodning.BryggeriId1,
                BryggeriId2 = samarbejdeAnmodning.BryggeriId2,
            };
            //}
            _context.SamarbejdeAnmodning.Add(samarbejdeAnmodning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamarbejdeAnmodning", new { id = samarbejdeAnmodning.Id }, samarbejdeAnmodning);
        }

        // DELETE: api/Brugere/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamarbejdeAnmodning(int id)
        {
            var user = await _context.SamarbejdeAnmodning.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.SamarbejdeAnmodning.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool SamarbejdeAnmodningExists(int id)
        {
            return (_context.SamarbejdeAnmodning?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
