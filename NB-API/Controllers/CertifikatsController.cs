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
    public class CertifikatsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public CertifikatsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/Certifikats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certifikat>>> GetCertifikat()
        {
          if (_context.Certifikat == null)
          {
              return NotFound();
          }
            return await _context.Certifikat.ToListAsync();
        }

        // GET: api/Certifikats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certifikat>> GetCertifikat(int id)
        {
          if (_context.Certifikat == null)
          {
              return NotFound();
          }
            var certifikat = await _context.Certifikat.FindAsync(id);

            if (certifikat == null)
            {
                return NotFound();
            }

            return certifikat;
        }

        // PUT: api/Certifikats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertifikat(int id, Certifikat certifikat)
        {
            if (id != certifikat.Id)
            {
                return BadRequest();
            }

            _context.Entry(certifikat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertifikatExists(id))
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

        // POST: api/Certifikats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Certifikat>> PostCertifikat(Certifikat certifikat)
        {
          if (_context.Certifikat == null)
          {
              return Problem("Entity set 'NBDBContext.Certifikat'  is null.");
          }
            _context.Certifikat.Add(certifikat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertifikat", new { id = certifikat.Id }, certifikat);
        }

        // DELETE: api/Certifikats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertifikat(int id)
        {
            if (_context.Certifikat == null)
            {
                return NotFound();
            }
            var certifikat = await _context.Certifikat.FindAsync(id);
            if (certifikat == null)
            {
                return NotFound();
            }

            _context.Certifikat.Remove(certifikat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertifikatExists(int id)
        {
            return (_context.Certifikat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
