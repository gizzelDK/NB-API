using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace NB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BryggeriFollowersController : ControllerBase
    {
        private readonly NBDBContext _context;

        public BryggeriFollowersController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/BryggeriFollowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BryggeriFollowers>>> GetBryggeriFollowers()
        {
            return await _context.BryggeriFollowers.ToListAsync();
        }

        // GET: api/BryggeriFollowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BryggeriFollowers>> GetBryggeriFollowers(int id)
        {
            var bryggeriFollowers = await _context.BryggeriFollowers.FindAsync(id);

            if (bryggeriFollowers == null)
            {
                return NotFound();
            }

            return bryggeriFollowers;
        }

        // PUT: api/BryggeriFollowers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize()]
        public async Task<IActionResult> PutBryggeriFollowers(int id, BryggeriFollowers bryggeriFollowers)
        {
            if (id != bryggeriFollowers.Id)
            {
                return BadRequest();
            }

            _context.Entry(bryggeriFollowers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BryggeriFollowersExists(id))
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

        // POST: api/BryggeriFollowers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize()]
        public async Task<ActionResult<BryggeriFollowers>> PostBryggeriFollowers(BryggeriFollowers bryggeriFollowers)
        {
            _context.BryggeriFollowers.Add(bryggeriFollowers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBryggeriFollowers", new { id = bryggeriFollowers.Id }, bryggeriFollowers);
        }

        // DELETE: api/BryggeriFollowers/5
        [HttpDelete("{id}"), Authorize()]
        public async Task<IActionResult> DeleteBryggeriFollowers(int id)
        {
            var bryggeriFollowers = await _context.BryggeriFollowers.FindAsync(id);
            if (bryggeriFollowers == null)
            {
                return NotFound();
            }

            _context.BryggeriFollowers.Remove(bryggeriFollowers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BryggeriFollowersExists(int id)
        {
            return _context.BryggeriFollowers.Any(e => e.Id == id);
        }
    }
}
