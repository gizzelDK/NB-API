using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;
using NB_API.Services;

namespace NB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontaktoplysningersController : ControllerBase
    {
        private readonly NBDBContext _context;
        private IHashingService _hashingService;
        private ICryptoService _cryptoService;

        public KontaktoplysningersController(NBDBContext context, IHashingService hashingService, ICryptoService cryptoService)
        {
            _context = context;
            _hashingService = hashingService;
            _cryptoService = cryptoService;

        }

        // GET: api/Kontaktoplysningers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kontaktoplysninger>>> GetKontaktoplysninger()
        {
            try
            {
                var kontaktoplysningerBrugerList = await _context.Kontaktoplysninger.ToListAsync();
                foreach (var i in kontaktoplysningerBrugerList)
                {                   
                    if (i.Email != null)
                    {
                        i.Email = _cryptoService.decrypt(i.Email);
                    }                                                         
                }
                return Ok(kontaktoplysningerBrugerList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET: api/Kontaktoplysningers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kontaktoplysninger>> GetKontaktoplysninger(int id)
        {
            try
            {
                var kontaktoplysningerBrugerList = await _context.Kontaktoplysninger.ToListAsync();
                foreach (var i in kontaktoplysningerBrugerList)
                {
                    if (i.Email != null)
                    {
                        i.Email = _cryptoService.decrypt(i.Email);
                    }
                }
                return Ok(kontaktoplysningerBrugerList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Kontaktoplysningers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontaktoplysninger(int id, Kontaktoplysninger kontaktoplysninger)
        {                               
                if (id != kontaktoplysninger.Id)
                {
                    return BadRequest();
                }
                var dbkontaktoplysninger = _context.Kontaktoplysninger.FirstOrDefault(k => k.Id == id);
            
                if (kontaktoplysninger.Id != null)
                {                  
                    dbkontaktoplysninger.Enavn = kontaktoplysninger.Enavn;
                    dbkontaktoplysninger.Fnavn = kontaktoplysninger.Fnavn;                   
                    dbkontaktoplysninger.Addresselinje1 = kontaktoplysninger.Addresselinje1;
                    dbkontaktoplysninger.Addresselinje2 = kontaktoplysninger.Addresselinje2;
                    dbkontaktoplysninger.Postnr = kontaktoplysninger.Postnr;
                    dbkontaktoplysninger.By = kontaktoplysninger.By;
                    dbkontaktoplysninger.Email = _cryptoService.encrypt(kontaktoplysninger.Email);
                    dbkontaktoplysninger.TelefonNr = kontaktoplysninger.TelefonNr;
            }
                if (kontaktoplysninger != null)
                {
                    dbkontaktoplysninger.Id = kontaktoplysninger.Id;
                }
                _context.Entry(dbkontaktoplysninger).State = EntityState.Modified;               

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

        }

        // POST: api/Kontaktoplysningers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kontaktoplysninger>> PostKontaktoplysninger(Kontaktoplysninger kontaktoplysninger)
        {
            if(kontaktoplysninger == null)
            {
                return BadRequest("kontaktoplysninger emty");
            }
          var emailcrypt = _cryptoService.encrypt(kontaktoplysninger.Email);     
          kontaktoplysninger.Email = emailcrypt;          
            _context.Kontaktoplysninger.Add(kontaktoplysninger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontaktoplysninger", new { id = kontaktoplysninger.Id }, kontaktoplysninger);
        }

        // DELETE: api/Kontaktoplysningers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKontaktoplysninger(int id)
        {
            if (_context.Kontaktoplysninger == null)
            {
                return NotFound();
            }
            var kontaktoplysninger = await _context.Kontaktoplysninger.FindAsync(id);
            if (kontaktoplysninger == null)
            {
                return NotFound();
            }

            _context.Kontaktoplysninger.Remove(kontaktoplysninger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KontaktoplysningerExists(int id)
        {
            return (_context.Kontaktoplysninger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
