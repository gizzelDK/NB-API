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
    public class EventsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public EventsController(NBDBContext context)
        {
            _context = context;
        }
        // Føj deltagere
        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
          if (_context.Event == null)
          {
              return NotFound();
          }
            return await _context.Event.ToListAsync();
        }
        // Føj deltagere
        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
          if (_context.Event == null)
          {
              return NotFound();
          }
            var @event = await _context.Event.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
          if (_context.Event == null)
          {
              return Problem("Entity set 'NBDBContext.Event'  is null.");
          }
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }


        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return (_context.Event?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
