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
    public class ForumTagsController : ControllerBase
    {
        private readonly NBDBContext _context;

        public ForumTagsController(NBDBContext context)
        {
            _context = context;
        }

        // GET: api/ForumTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumTags>>> GetForumTags()
        {
          if (_context.ForumTags == null)
          {
              return NotFound();
          }
            return await _context.ForumTags.ToListAsync();
        }

        // GET: api/ForumTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumTags>> GetForumTags(int id)
        {
          if (_context.ForumTags == null)
          {
              return NotFound();
          }
            var forumTags = await _context.ForumTags.FindAsync(id);

            if (forumTags == null)
            {
                return NotFound();
            }

            return forumTags;
        }

        // PUT: api/ForumTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForumTags(int id, ForumTags forumTags)
        {
            if (id != forumTags.Id)
            {
                return BadRequest();
            }

            _context.Entry(forumTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumTagsExists(id))
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

        // POST: api/ForumTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ForumTags>> PostForumTags(ForumTags forumTags)
        {
            var tags = await _context.ForumTags.Where(f => f.TagId == forumTags.TagId && f.ForumId == forumTags.ForumId).ToListAsync();
            if (forumTags.ForumId == null || forumTags.TagId == null)
            {
                return BadRequest("mangler enten forumid eller tagId");
            }
            if (tags != null)
            {
                return BadRequest("Tag findes allerede:" + tags[0].Id);
            }
            

            _context.ForumTags.Add(forumTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ForumTags", new { id = forumTags.Id }, forumTags);

            //return (_context.ForumTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE: api/ForumTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForumTags(int id)
        {
            if (_context.ForumTags == null)
            {
                return NotFound();
            }
            var forumTags = await _context.ForumTags.FindAsync(id);
            if (forumTags == null)
            {
                return NotFound();
            }

            _context.ForumTags.Remove(forumTags);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumTagsExists(int id)
        {
            return (_context.ForumTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
