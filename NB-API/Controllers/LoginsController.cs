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
    public class LoginsController : ControllerBase
    {
        private readonly NBDBContext _context;
        private readonly IHashingService _hashingservice;
        private ICryptoService _cryptoService;

        /// <summary>
        /// configurations er vores Tokens dvs. får fat i settings.jason fil
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public LoginsController(NBDBContext context, IHashingService hashingService, ICryptoService cryptoService)
        {
            _context = context;
            _hashingservice = hashingService;
            _cryptoService = cryptoService;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            return await _context.Login.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {        
            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        /// No Put and no delete for login 

        /// POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(LoginDto login)
        {
            //as no tracking = ændring ikke slår igennem i DB
            var brugerlist = await _context.Bruger.AsNoTracking().ToListAsync();
            foreach (var i in brugerlist)
            {
                var brugernavn = _cryptoService.decrypt(i.Brugernavn);
                if (brugernavn == login.Brugernavn)
                {

                    if (!_hashingservice.VerifyHash(login.Pw, i.PwHash, i.PwSalt))
                    {
                        return Unauthorized("Wrong password");
                    }
                    string token = _hashingservice.CreateToken(i);
                    i.Brugernavn = _cryptoService.decrypt(i.Brugernavn);
                    var dblogin = new Login();
                    dblogin.BrugerId = i.Id;
                    dblogin.Bruger = i;
                    dblogin.LoginTime = DateTime.Now;
                    /// Make sure not to create new users on login = entrystate.unchanged
                    _context.Entry(dblogin.Bruger).State = EntityState.Unchanged;
                    _context.Login.Add(dblogin);
                    await _context.SaveChangesAsync();
                    return Ok("{ \"bearer\":\"" + token + "\"}");
                    
                }
                
            }
            return BadRequest("Brugernavn eksisterer ikke");
        }

       

        private bool LoginExists(int id)
        {
            return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
