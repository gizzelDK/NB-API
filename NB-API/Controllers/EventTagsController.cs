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
    public class EventTagsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public EventTagsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/EventTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTags>>> GetEventTags()
        {
          if (_context.EventTags == null)
          {
              return NotFound();
          }
            return await _context.EventTags.ToListAsync();
        }

        // GET: api/EventTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTags>> GetEventTags(int id)
        {
          if (_context.EventTags == null)
          {
              return NotFound();
          }
            var eventTags = await _context.EventTags.FindAsync(id);

            if (eventTags == null)
            {
                return NotFound();
            }

            return eventTags;
        }

        // PUT: api/EventTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTags(int id, EventTags eventTags)
        {
            if (id != eventTags.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTagsExists(id))
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

        // POST: api/EventTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventTags>> PostEventTags(EventTags eventTags)
        {
          if (_context.EventTags == null)
          {
              return Problem("Entity set 'NBDBContext.EventTags'  is null.");
          }
            _context.EventTags.Add(eventTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTags", new { id = eventTags.Id }, eventTags);
        }

        // DELETE: api/EventTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTags(int id)
        {
            if (_context.EventTags == null)
            {
                return NotFound();
            }
            var eventTags = await _context.EventTags.FindAsync(id);
            if (eventTags == null)
            {
                return NotFound();
            }

            _context.EventTags.Remove(eventTags);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventTagsExists(int id)
        {
            return (_context.EventTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
