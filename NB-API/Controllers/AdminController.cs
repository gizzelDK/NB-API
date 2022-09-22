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

       // [HttpDelete("Oprydning/Brugere")]
        [HttpDelete("Oprydning/Brugere/{id}")]
        public async Task<IActionResult> CleanupDeletedUsers(int id)
        {
            var result =  _context.Bruger.Where(b => b.DeleteTime != null && b.DeleteTime.Value.AddDays(92) < DateTime.Now.Date ).ToList();
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
