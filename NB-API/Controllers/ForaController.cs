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
    public class ForaController : ControllerBase
    {
        private readonly NBDBContext _context;

        public ForaController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Fora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forum>>> GetForum()
        {
          if (_context.Forum == null)
          {
              return NotFound();
          }
            return await _context.Forum.ToListAsync();
        }

        // GET: api/Fora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forum>> GetForum(int id)
        {
          if (_context.Forum == null)
          {
              return NotFound();
          }
            var forum = await _context.Forum.FindAsync(id);

            if (forum == null)
            {
                return NotFound();
            }

            return forum;
        }

        // PUT: api/Fora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForum(int id, Forum forum)
        {
            if (id != forum.Id)
            {
                return BadRequest();
            }

            _context.Entry(forum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Fora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forum>> PostForum(Forum forum)
        {
          if (_context.Forum == null)
          {
              return Problem("Entity set 'NBDBContext.Forum'  is null.");
          }
            _context.Forum.Add(forum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForum", new { id = forum.Id }, forum);
        }

        // DELETE: api/Fora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(int id)
        {
            if (_context.Forum == null)
            {
                return NotFound();
            }
            var forum = await _context.Forum.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            _context.Forum.Remove(forum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumExists(int id)
        {
            return (_context.Forum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
