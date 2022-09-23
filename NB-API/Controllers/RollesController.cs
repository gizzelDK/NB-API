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
    public class RollesController : ControllerBase
    {
        private readonly NBDBContext _context;

        public RollesController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Rolles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rolle>>> GetRolle()
        {
          if (_context.Rolle == null)
          {
              return NotFound();
          }
            return await _context.Rolle.ToListAsync();
        }

        // GET: api/Rolles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rolle>> GetRolle(int id)
        {
          if (_context.Rolle == null)
          {
              return NotFound();
          }
            var rolle = await _context.Rolle.FindAsync(id);

            if (rolle == null)
            {
                return NotFound();
            }

            return rolle;
        }

        // PUT: api/Rolles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutRolle(int id, Rolle rolle)
        {
            if (id != rolle.Id)
            {
                return BadRequest();
            }

            _context.Entry(rolle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolleExists(id))
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

        // POST: api/Rolles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Rolle>> PostRolle(Rolle rolle)
        {
          if (_context.Rolle == null)
          {
              return Problem("Entity set 'NBDBContext.Rolle'  is null.");
          }
            _context.Rolle.Add(rolle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolle", new { id = rolle.Id }, rolle);
        }

        // DELETE: api/Rolles/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteRolle(int id)
        {
            if (_context.Rolle == null)
            {
                return NotFound();
            }
            var rolle = await _context.Rolle.FindAsync(id);
            if (rolle == null)
            {
                return NotFound();
            }

            _context.Rolle.Remove(rolle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolleExists(int id)
        {
            return (_context.Rolle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
