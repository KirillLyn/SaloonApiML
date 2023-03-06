using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaloonApiML.Model;

namespace SaloonApiML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly BeautySaloonContext _context;

        public GendersController(BeautySaloonContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(string id)
        {
            var gender = await _context.Genders.FindAsync(id);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(string id, Gender gender)
        {
            if (id != gender.Code)
            {
                return BadRequest();
            }

            _context.Entry(gender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _context.Genders.Add(gender);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GenderExists(gender.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGender", new { id = gender.Code }, gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(string id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenderExists(string id)
        {
            return _context.Genders.Any(e => e.Code == id);
        }
    }
}
