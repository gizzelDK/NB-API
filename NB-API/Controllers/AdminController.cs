using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NB_API.Models;

namespace NB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly NBDBContext _context;

        public AdminController(NBDBContext context)
        {
            _context = context;
        }

       // [HttpDelete("Oprydning/Brugere"), Authorize(Roles = "Administrator")]
        [HttpDelete("Oprydning/Brugere")]
        public async Task<IActionResult> CleanupDeletedUsers()
        {
            int deleted = 0;
            var result = _context.Bruger.Where(b => b.DeleteTime.Value.AddDays(92) < DateTime.Now.Date ).ToList();
            if (result == null)
            {
                return NoContent();
            }
            try
            {
                deleted = result.Count();
                foreach(var item in result)
                {
                    _context.Bruger.Remove(item);
                }
                await _context.SaveChangesAsync();
                return Ok("Brugere slettet\": " + deleted);
            }
            catch (Exception e)
            {

                return BadRequest("Dette gik galt: " + e.Message);
            }
        }
    }
}
