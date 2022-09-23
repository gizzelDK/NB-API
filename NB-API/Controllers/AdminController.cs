using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace NB_API.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "Administrator")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly NBDBContext _context;

        public AdminController(NBDBContext context)
        {
            _context = context;
        }

        // Get BrugereUpForDeletion()
        [HttpGet("Oprydning/Brugere")]
        public async Task<ActionResult<Bruger>> BrugereUpForDeletion()
        {
            if (_context == null)

	        {
                return NoContent();
	        }
            var result = await _context.Bruger.Where(b => b.DeleteTime != null && b.DeleteTime.Value.AddDays(92) < DateTime.Now.Date).ToListAsync();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

       // [HttpDelete("Oprydning/Brugere")]
        [HttpDelete("Oprydning/Brugere/{id}")]
        public async Task<ActionResult<Bruger>> CleanupDeletedUsers(int id)
        {
            var result =  await _context.Bruger.Where(b => b.DeleteTime != null && b.DeleteTime.Value.AddDays(92) < DateTime.Now.Date ).ToListAsync();
            if (result == null)
            {
                return NoContent();
            }
            try
            {
                if (result != null)
                {
                    foreach(var item in result)
                    {
                       _context.Bruger.Remove(item);
                    }
                    await _context.SaveChangesAsync();

                }
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest("Dette gik galt: " + e.InnerException.Message);
            }
        }
    }
}
