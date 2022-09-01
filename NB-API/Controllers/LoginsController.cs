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

        /// <summary>
        /// configurations er vores Tokens dvs. får fat i settings.jason fil
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public LoginsController(NBDBContext context, IHashingService hashingService)
        {
            _context = context;
            _hashingservice = hashingService;
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

        //No Put for login 

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(LoginDto login)
        {
            var bruger = await _context.Bruger.AsNoTracking().FirstOrDefaultAsync(b => b.Brugernavn == login.Brugernavn);
          
            if(bruger == null)
            {
                return BadRequest("No such user was found");
            }

            if(!_hashingservice.VerifyHash(login.Pw, bruger.PwHash, bruger.PwSalt))
            {
                return Unauthorized("Wrong password");
            }
            string token = _hashingservice.CreateToken(bruger);
            var dblogin = new Login();
            dblogin.BrugerId = bruger.Id;
            dblogin.Bruger = bruger;
            /// Make sure not to create new users on login
            _context.Entry(dblogin.Bruger).State = EntityState.Unchanged;
            _context.Login.Add(dblogin);
            await _context.SaveChangesAsync();
            return Accepted("{ \"bearer\":\"" + token + "\"}");

        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            if (_context.Login == null)
            {
                return NotFound();
            }
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
