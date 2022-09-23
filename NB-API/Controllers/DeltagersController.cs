using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;
using NB_API.Services;

namespace NB_API.Controllers
{
    [Route("api/[controller]"), Authorize()]
    [ApiController]
    public class DeltagersController : ControllerBase
    {
        private readonly NBDBContext _context;
        private IHashingService _hashingService;
        private ICryptoService _cryptoService;

        public DeltagersController(NBDBContext context, IHashingService hashingService, ICryptoService cryptoService)
        {
            _context = context;
            _hashingService = hashingService;
            _cryptoService = cryptoService;
        }

        // GET: api/Deltagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deltager>>> GetDeltager()
        {
            if (_context.Deltager == null)
            {
                return NotFound();
            }
            var deltagere = await _context.Deltager.ToListAsync();
            var dtoList = new List<DeltagerDto>();
            foreach(var i in deltagere)
            {
                BrugerDto brugerDto = new BrugerDto();
                DeltagerDto deltagerDto = new DeltagerDto();
                var bruger = _context.Bruger.Find(i.BrugerId);
                brugerDto.Id = bruger.Id;
                brugerDto.Brugernavn = _cryptoService.decrypt(bruger.Brugernavn);
                brugerDto.KontaktoplysningerId = bruger.KontaktoplysningerId;
                brugerDto.Kontaktoplysninger = bruger.Kontaktoplysninger;
                brugerDto.RolleId = bruger.RolleId;
                brugerDto.Rolle = bruger.Rolle;
                brugerDto.Certifikats = bruger.Certifikats;
                deltagerDto.Id = i.Id;
                deltagerDto.BrugerId = i.BrugerId;
                deltagerDto.EventId = i.EventId;
                deltagerDto.Bruger = brugerDto;
                //deltagerDto.Event = _context.Event.Find(i.EventId); // Bedre null - burde blive fanget af serialize

                dtoList.Add(deltagerDto);
            }
           
            return Ok(dtoList);
        }

        // GET: api/Deltagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeltagerDto>> GetDeltager(int id)
        {
          if (_context.Deltager == null)
          {
              return NotFound();
          }
            var deltager = await _context.Deltager.FindAsync(id);

            if (deltager == null)
            {
                return NotFound();
            }
            BrugerDto brugerDto = new BrugerDto();
            DeltagerDto deltagerDto = new DeltagerDto();
            var bruger = _context.Bruger.Find(deltager.BrugerId);
            brugerDto.Id = bruger.Id;
            brugerDto.Brugernavn = _cryptoService.decrypt(bruger.Brugernavn);
            brugerDto.KontaktoplysningerId = bruger.KontaktoplysningerId;
            brugerDto.Kontaktoplysninger = bruger.Kontaktoplysninger;
            brugerDto.RolleId = bruger.RolleId;
            brugerDto.Rolle = bruger.Rolle;
            brugerDto.Certifikats = bruger.Certifikats;
            deltagerDto.Id = deltager.Id;
            deltagerDto.BrugerId =deltager.BrugerId;
            deltagerDto.EventId = deltager.EventId;
            deltagerDto.Bruger = brugerDto;

            return deltagerDto;
        }

        // PUT: api/Deltagers/5 ----------- Modificerer man nogensinde deltagelse? Enten deltager man, eller man sleter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDeltager(int id, Deltager deltager)
        //{
        //    if (id != deltager.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(deltager).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeltagerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Deltagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deltager>> PostDeltager(DeltagerDto deltager)
        {
          if (_context.Deltager == null)
          {
              return Problem("Entity set 'NBDBContext.Deltager'  is null.");
          }
            var dbDeltager = new Deltager();
            dbDeltager.Id = deltager.Id;
            dbDeltager.BrugerId = deltager.BrugerId;
            dbDeltager.EventId = deltager.EventId;

            _context.Deltager.Add(dbDeltager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeltager", new { id = deltager.Id }, deltager);
        }

        // DELETE: api/Deltagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeltager(int id)
        {
            if (_context.Deltager == null)
            {
                return NotFound();
            }
            var deltager = await _context.Deltager.FindAsync(id);
            if (deltager == null)
            {
                return NotFound();
            }

            _context.Deltager.Remove(deltager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeltagerExists(int id)
        {
            return (_context.Deltager?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
