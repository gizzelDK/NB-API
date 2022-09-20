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
                var brugerList = await _context.Bruger.Include(x => x.Certifikats).ToListAsync();
                var dtoList = new List<BrugerDto>();
                foreach (var i in brugerList)
                {

                    if (i == null || i.Deleted == true)
                    {
                        continue;
                    }
                    else
                    {
                    var bruger = new BrugerDto();
                    bruger.Id = i.Id;
                    bruger.Brugernavn = _cryptoService.decrypt(i.Brugernavn);
                    bruger.KontaktoplysningerId = i.KontaktoplysningerId;
                    bruger.Kontaktoplysninger = i.Kontaktoplysninger;
                    bruger.RolleId = i.RolleId;
                    bruger.Rolle = i.Rolle;
                    bruger.Deltager = i.Deltager;
                    bruger.Certifikats = i.Certifikats;
                    dtoList.Add(bruger);
                    }
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

                if (bruger == null || bruger.Deleted == true)
                {
                    return NotFound();
                }
                var brugerDto = new BrugerDto();

                    brugerDto.Id = bruger.Id;
                    brugerDto.Brugernavn = _cryptoService.decrypt(bruger.Brugernavn);
                    brugerDto.KontaktoplysningerId = bruger.KontaktoplysningerId;
                    brugerDto.Kontaktoplysninger = bruger.Kontaktoplysninger;
                    brugerDto.RolleId = bruger.RolleId;
                    brugerDto.Rolle = bruger.Rolle;
                    brugerDto.Deltager = bruger.Deltager;
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
        public async Task<IActionResult> PutBrugerRolle(int rolle, BrugerDto bruger)
        {
            try
            {
                var dbBruger = await _context.Bruger.FindAsync(bruger.Id);

                if (dbBruger == null)
                {
                    return NotFound();
                }
                // Ændrer kun fk RolleId
                dbBruger.RolleId = rolle;

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

        // PUT api/Brugere/pw
        [HttpPut("pw/{id}")]
        public async Task<IActionResult> PutBrugerPw(int id, PwDto pwDto)
        {
            try
            {
                var brugerTmp = await _context.Bruger.FindAsync(id);

                if (brugerTmp == null)
                {
                    return NotFound();
                }
                if (!_hashingService.VerifyHash(pwDto.OldPw, brugerTmp.PwHash, brugerTmp.PwSalt))
                {
                    return Unauthorized("Wrong Password!");
                }
                var retHash = _hashingService.CreateHash(pwDto.NewPw);
                brugerTmp.PwHash = (byte[])retHash[1];
                brugerTmp.PwSalt = (byte[])retHash[0];

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

        // PUT: api/Brugers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, BrugerDto bruger)
        {
            try
            {
                if (id != bruger.Id)
                {
                    return BadRequest();
                }

                var dbBruger = _context.Bruger.AsNoTracking().FirstOrDefault(b => b.Id == id);

                if (bruger.Brugernavn != null)
                {
                    dbBruger.Brugernavn = _cryptoService.encrypt(bruger.Brugernavn);
                }
                if (bruger.KontaktoplysningerId != null)
                {
                dbBruger.KontaktoplysningerId = bruger.KontaktoplysningerId;
                }

                _context.Entry(dbBruger).State = EntityState.Modified;

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
        // PUT: api/Brugers/Offentlighed/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Offentlighed/{id}")]
        public async Task<IActionResult> PutBrugerPrivacySetting(int id, bool setting)
        {
            try
            {
                var bruger = _context.Bruger.Find(id);
                if (bruger == null)
                {
                    return BadRequest();
                }
                var kontaktoplysninger = _context.Kontaktoplysninger.Find(bruger.KontaktoplysningerId);
                if (bruger == null)
                {
                    return BadRequest();
                }
                kontaktoplysninger.Offentlig = setting;

                _context.Entry(kontaktoplysninger).State = EntityState.Modified;

                 await _context.SaveChangesAsync();

                    return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
         // PUT: api/Brugers/AcceptedPolicy/{BrugerId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("AcceptedPolicy/{id}")]
        public async Task<IActionResult> PutBrugerAcceptedPolicy(int id, bool setting)
        {
            try
            {
                var bruger = _context.Bruger.Find(id);
                if (bruger == null)
                {
                    return BadRequest();
                }
                bruger.AcceptedPolicy = setting;

                _context.Entry(bruger).State = EntityState.Modified;

                 await _context.SaveChangesAsync();

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
                    try
                    {
                        i.Brugernavn = _cryptoService.decrypt(i.Brugernavn);
                        if (i.Brugernavn == bruger.Brugernavn)
                        {
                            return BadRequest("Brugernavn eksisterer allerede");
                        }

                    }
                    catch (Exception)
                    {

                        continue;
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
                returBruger.Brugernavn = bruger.Brugernavn;
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


         //DELETE: api/Brugers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(int id)
        {
            try
            {
                if (_context.Bruger == null)
                {
                    return NotFound();
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

                return NoContent(); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        // hent brugere med efternavn
        [HttpGet("enavn/{enavn}")]
        public async Task<ActionResult<Bruger>> GetBrugerEnavn(string enavn)
        {
            var joinBrugerKontaktOplysninger = await _context.Bruger.Join(_context.Kontaktoplysninger,
                                                                            kontatkoplysninger => kontatkoplysninger.Id,
                                                                            bruger => bruger.Id,
                                                                            (kontaktOplysninger, bruger) => new
                                                                            {
                                                                                enavn = kontaktOplysninger.Kontaktoplysninger.Enavn,
                                                                                rollenavn = kontaktOplysninger.Rolle.RolleNavn,
                                                                                id = bruger.Id,
                                                                                brugernavn=_cryptoService.decrypt(kontaktOplysninger.Brugernavn)
                                                                            }).Where(x => x.enavn == enavn).ToListAsync();

           
            return Ok(joinBrugerKontaktOplysninger);
        }
        //hente bruger med email parameter
        // GET: api/Brugere/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Bruger>> GetBrugerEmail(string email)
        {
            var joinBrugerKontaktOplysninger = await _context.Bruger.Join(_context.Kontaktoplysninger,
                                                                            kontaktOplysninger => kontaktOplysninger.Id,
                                                                            bruger => bruger.Id,
                                                                            (kontaktOplysninger, bruger) => new
                                                                            {
                                                                                email = kontaktOplysninger.Kontaktoplysninger.Email,
                                                                                brugernavn =_cryptoService.decrypt(kontaktOplysninger.Brugernavn),
                                                                                id = bruger.Id
                                                                            }).Where(x => x.email == email).ToListAsync();
            return Ok(joinBrugerKontaktOplysninger);
        }

        /// hente brugere med access lvl
        [HttpGet("level/{level}")]
        public async Task<ActionResult<Bruger>> GetBrugerRolleNavn(int level)
        {
            var joinBrugerRolle = await _context.Bruger.Join(_context.Rolle,
                                                                            Rolle => Rolle.Id,
                                                                            Bruger => Bruger.Id,
                                                                            (Rolle, Bruger) => new
                                                                            {
                                                                                level = Rolle.Rolle.Level,
                                                                                brugernavn = Rolle.Brugernavn,
                                                                                id = Bruger.Id
                                                                            }).Where(x => x.level == level).ToListAsync();
            return Ok(joinBrugerRolle);
        }
        //hente bruger med eventsTitel parameter
        // GET: api/Brugere/email/{email}
        [HttpGet("titel/{titel}")]
        public async Task<ActionResult<Bruger>> GetBrugerEventsTitel(string titel)
        {
            var joinBrugerEventsTitel = await _context.Bruger.Join(_context.Deltager,
                                                                    bruger => bruger.Id,
                                                                    deltagelse => deltagelse.BrugerId,
                                                                    (bruger, deltagelse) => new { bruger, deltagelse })
                                                                    .Join(_context.Event,
                                                                    deltagelse => deltagelse.deltagelse.EventId,
                                                                    events => events.Id,
                                                                    (deltagelse, events) => new { deltagelse = deltagelse, events })
                                                                    .Where(x => x.events.Titel == titel)
                                                                    .Select(bruger => new
                                                                    {
                                                                        //titel = Bruger.events.Titel,
                                                                        id = bruger.deltagelse.bruger.Id,
                                                                        brugernavn = bruger.deltagelse.bruger.Brugernavn,
                                                                        email = bruger.deltagelse.bruger.Kontaktoplysninger.Email,
                                                                        enavn = bruger.deltagelse.bruger.Kontaktoplysninger.Enavn,
                                                                        fnavn = bruger.deltagelse.bruger.Kontaktoplysninger.Fnavn,
                                                                        adresseLinje1 = bruger.deltagelse.bruger.Kontaktoplysninger.Addresselinje1,
                                                                        adresseLinje2 = bruger.deltagelse.bruger.Kontaktoplysninger.Addresselinje2,
                                                                        postNr = bruger.deltagelse.bruger.Kontaktoplysninger.Postnr,
                                                                        telefonNr = bruger.deltagelse.bruger.Kontaktoplysninger.TelefonNr,
                                                                        by = bruger.deltagelse.bruger.Kontaktoplysninger.By
                                                                    })
                                                                    .ToListAsync();
            return Ok(joinBrugerEventsTitel);
        }


        private bool BrugerExists(int id)
        {
            return (_context.Bruger?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
