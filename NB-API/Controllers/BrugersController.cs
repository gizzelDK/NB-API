﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public BrugersController(NBDBContext context, IHashingService hashingService)
        {
            _context = context;
            _hashingService = hashingService;
        }

        // GET: api/Brugers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bruger>>> GetBruger()
        {
            var brugerList = await _context.Bruger.ToListAsync();
            var dtoList = new List<BrugerDto>();
            foreach (var i in brugerList)
            {
                var bruger = new BrugerDto();
                bruger.Id = i.Id;
                bruger.Brugernavn = i.Brugernavn;
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

        // GET: api/Brugers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bruger>> GetBruger(int id)
        {
            var bruger = await _context.Bruger.FindAsync(id);
            var brugerDto = new BrugerDto();

            if (bruger == null)
            {
                return NotFound();
            }

            brugerDto.Id = bruger.Id;
            brugerDto.Brugernavn = bruger.Brugernavn;
            brugerDto.KontaktoplysningerId = bruger.KontaktoplysningerId;
            brugerDto.Kontaktoplysninger = bruger.Kontaktoplysninger;
            brugerDto.RolleId = bruger.RolleId;
            brugerDto.Rolle = bruger.Rolle;
            brugerDto.Events = bruger.Events;
            brugerDto.Certifikats = bruger.Certifikats;

            return Ok(brugerDto);
        }

        // PUT api/Brugere/rolle?rolle=4&id=3
        [HttpPut("rolle"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutBrugerRolle(int rolle, int id)
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

            return NoContent();
        }

        // PUT api/Brugere/pw
        [HttpPut("pw")]
        public async Task<IActionResult> PutBrugerPw(Bruger bruger, string oldPw, string newPw)
        {
            var brugerTmp = await _context.Bruger.FindAsync(bruger.Id);

            if (brugerTmp == null)
            {
                return NotFound();
            }
            if (!_hashingService.VerifyHash(oldPw, brugerTmp.PwHash, brugerTmp.PwSalt))
            {
                return BadRequest("Bad Password!");
            }
            var retHash = _hashingService.CreateHash(newPw);
            bruger.PwHash = (byte[])retHash[1];
            bruger.PwSalt = (byte[])retHash[0];

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

            return NoContent();
        }

        // PUT: api/Brugers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
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

        // POST: api/Brugere
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bruger>> PostBruger(BrugerDto bruger)
        {
            var nybruger = new Bruger();
            nybruger.KontaktoplysningerId = bruger.KontaktoplysningerId;
            nybruger.RolleId = bruger.RolleId;
            nybruger.Brugernavn = bruger.Brugernavn;
            var retHash = _hashingService.CreateHash(bruger.Pw);
            nybruger.PwHash = (byte[])retHash[1];
            nybruger.PwSalt = (byte[])retHash[0];

            _context.Bruger.Add(nybruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruger", new { id = nybruger.Id }, nybruger);
        }


        // DELETE: api/Brugers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(int id)
        {
            if (_context.Bruger == null)
            {
                return NotFound();
            }
            var bruger = await _context.Bruger.FindAsync(id);
            if (bruger == null)
            {
                return NotFound();
            }

            _context.Bruger.Remove(bruger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrugerExists(int id)
        {
            return (_context.Bruger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
