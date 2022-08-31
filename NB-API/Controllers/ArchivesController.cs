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
    public class ArchivesController : ControllerBase
    {
        private readonly NBDBContext _context;

        public ArchivesController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Archives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archive>>> GetArchive()
        {
          if (_context.Archive == null)
          {
              return NotFound();
          }
            return await _context.Archive.ToListAsync();
        }

        // GET: api/Archives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archive>> GetArchive(int id)
        {
          if (_context.Archive == null)
          {
              return NotFound();
          }
            var archive = await _context.Archive.FindAsync(id);

            if (archive == null)
            {
                return NotFound();
            }

            return archive;
        }

        // PUT: api/Archives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchive(int id, Archive archive)
        {
            if (id != archive.Id)
            {
                return BadRequest();
            }

            _context.Entry(archive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveExists(id))
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

        // POST: api/Archives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Archive>> PostArchive(Archive archive)
        {
          if (_context.Archive == null)
          {
              return Problem("Entity set 'NBDBContext.Archive'  is null.");
          }
            _context.Archive.Add(archive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchive", new { id = archive.Id }, archive);
        }

        // DELETE: api/Archives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchive(int id)
        {
            if (_context.Archive == null)
            {
                return NotFound();
            }
            var archive = await _context.Archive.FindAsync(id);
            if (archive == null)
            {
                return NotFound();
            }

            _context.Archive.Remove(archive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchiveExists(int id)
        {
            return (_context.Archive?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
