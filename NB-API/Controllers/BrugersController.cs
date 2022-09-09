using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NB_API.Models;
using NB_API.Services;

namespace NB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugersController : ControllerBase
    {
        private readonly NBDBContext _context;
        private IHashingService _hashingService;
        private ICryptoService _cryptoService;

        public BrugersController(NBDBContext context, IHashingService hashingService, ICryptoService cryptoService)
        {
            _context = context;
            _hashingService = hashingService;
            _cryptoService = cryptoService;
        }

        // GET: api/Brugers
        //GET: protected with admin
        [HttpGet]
        //[HttpGet, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<Bruger>>> GetBruger()
        {
            try
            {
                var brugerList = await _context.Bruger.ToListAsync();
                var dtoList = new List<BrugerDto>();
                foreach (var i in brugerList)
                {

                    if (i == null || i.Deleted == true)
                    {
                        continue;
                    }

                    var bruger = new BrugerDto();
                    bruger.Id = i.Id;
                    bruger.Brugernavn = _cryptoService.decrypt(i.Brugernavn);
                    bruger.KontaktoplysningerId = i.KontaktoplysningerId;
                    bruger.Kontaktoplysninger = i.Kontaktoplysninger;
                    bruger.RolleId = i.RolleId;
                    bruger.Rolle = i.Rolle;
                    bruger.Events = i.Events;
                    bruger.Certifikats = i.Certifikats;
                    dtoList.Add(bruger);                  
                }
                return Ok(dtoList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
            
        }

        // GET: api/Brugers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bruger>> GetBruger(int id)
        {
            try
            {
                var bruger = await _context.Bruger.FindAsync(id);
                var brugerDto = new BrugerDto();

                if (bruger == null || bruger.Deleted == true)
                {
                    return NotFound();
                }

                brugerDto.Id = bruger.Id;
                brugerDto.Brugernavn = _cryptoService.decrypt(bruger.Brugernavn);
                brugerDto.KontaktoplysningerId = bruger.KontaktoplysningerId;
                brugerDto.Kontaktoplysninger = bruger.Kontaktoplysninger;
                brugerDto.RolleId = bruger.RolleId;
                brugerDto.Rolle = bruger.Rolle;
                brugerDto.Events = bruger.Events;
                brugerDto.Certifikats = await _context.Certifikat.ToListAsync();

                return Ok(brugerDto);

                
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        // PUT api/Brugere/rolle?rolle=4&id=3
        [HttpPut("rolle"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutBrugerRolle(int rolle, int id)
        {
            try
            {
                var bruger = await _context.Bruger.FindAsync(id);

                if (bruger == null)
                {
                    return NotFound();
                }
                // Ændrer kun fk RolleId
                bruger.RolleId = rolle;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrugerExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        // PUT api/Brugere/pw
        [HttpPut("pw")]
        public async Task<IActionResult> PutBrugerPw(Bruger bruger, string oldPw, string newPw)
        {
            try
            {
                var brugerTmp = await _context.Bruger.FindAsync(bruger.Id);

                if (brugerTmp == null)
                {
                    return NotFound();
                }
                if (!_hashingService.VerifyHash(oldPw, brugerTmp.PwHash, brugerTmp.PwSalt))
                {
                    return Unauthorized("Wrong Password!");
                }
                var retHash = _hashingService.CreateHash(newPw);
                brugerTmp.PwHash = (byte[])retHash[1];
                brugerTmp.PwSalt = (byte[])retHash[0];

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrugerExists(bruger.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok();
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
           
        }

        // PUT: api/Brugers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
        {
            try
            {
                if (id != bruger.Id)
                {
                    return BadRequest();
                }

                _context.Entry(bruger).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrugerExists(id))
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        // POST: api/Brugere
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bruger>> PostBruger(BrugerDto bruger)
        {
            try
            {
                //as no tracking = ændring ikke slår igennem i DB
                var brugerlist = await _context.Bruger.AsNoTracking().ToListAsync();
                foreach (var i in brugerlist)
                {
                    i.Brugernavn = _cryptoService.decrypt(i.Brugernavn);
                    if (i.Brugernavn == bruger.Brugernavn)
                    {
                        return BadRequest("Brugernavn eksisterer allerede");
                    }
                }

                var returBruger = new BrugerDto();
                var nybruger = new Bruger();
                nybruger.KontaktoplysningerId = bruger.KontaktoplysningerId;
                nybruger.RolleId = bruger.RolleId;
                var retHash = _hashingService.CreateHash(bruger.Pw);

                nybruger.PwHash = (byte[])retHash[1];
                nybruger.PwSalt = (byte[])retHash[0];
                nybruger.Brugernavn = _cryptoService.encrypt(bruger.Brugernavn);

                _context.Bruger.Add(nybruger);
                await _context.SaveChangesAsync();

                returBruger.Id = nybruger.Id;
                returBruger.Brugernavn = nybruger.Brugernavn;
                returBruger.KontaktoplysningerId = nybruger.KontaktoplysningerId;
                returBruger.Kontaktoplysninger = nybruger.Kontaktoplysninger;
                returBruger.RolleId = nybruger.RolleId;
                returBruger.Rolle = nybruger.Rolle;

                return CreatedAtAction("GetBruger", new { id = nybruger.Id }, returBruger);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        //flag feature
         //DELETE: api/Brugers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(int id, BrugerDto bruger)
        {
            try
            {
                if (_context.Bruger == null)
                {
                    return NotFound();
                }
                if (!_hashingService.VerifyBrugerId(id, bruger.Id))
                {
                    return Unauthorized("You do not have permission to Delete Users!");
                }

                var delbruger = await _context.Bruger.FindAsync(id);
                //bruger er nu en deleted bruger ned efter --> sætter bruger til true med et timestamp
                if (delbruger == null)
                {
                    return NotFound();
                }
                if (delbruger.Deleted)
                {
                    return BadRequest("User already Deleted on: " + delbruger.DeleteTime);
                }
                delbruger.Deleted = true;
                delbruger.DeleteTime = DateTime.Now;
                //_context.Bruger.Remove(bruger);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        //[HttpGet("enavn/{enavn}")]
        //public async Task<ActionResult<Bruger>> GetBrugerEnavn(string enavn)
        //{
        //    var joinBrugerKontaktOplysninger = await _context.Bruger.Join(_context.Kontaktoplysninger,
        //                                                                    kontatkoplysninger => kontatkoplysninger.Id,
        //                                                                    bruger => bruger.Id,
        //                                                                    (kontaktOplysninger, bruger) => new
        //                                                                    {
        //                                                                        enavn = kontaktOplysninger.Kontaktoplysninger.Enavn,
        //                                                                        brugernavn = kontaktOplysninger.Brugernavn,
        //                                                                        id = bruger.Id
        //                                                                    }).Where(x => x.enavn == enavn).ToListAsync();

        //    var dtoList = new List<BrugerDto>();
        //    foreach (var i in joinBrugerKontaktOplysninger)
        //    {
        //        var bruger = new BrugerDto();
        //        bruger.Id = i.id;
        //        bruger.Brugernavn = i.brugernavn;
        //        bruger.KontaktoplysningerId = i.KontaktoplysningerId;
        //        bruger.Kontaktoplysninger = i.Kontaktoplysninger;
        //        bruger.RolleId = i.RolleId;
        //        bruger.Rolle = i.Rolle;
        //        bruger.Events = i.Events;
        //        bruger.Certifikat = i.Certifikat;
        //        dtoList.Add(bruger);
        //    }
        //    return Ok(dtoList);
        //}

        private bool BrugerExists(int id)
        {
            return (_context.Bruger?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
