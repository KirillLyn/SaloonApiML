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
    public class ServiceCategoryesController : ControllerBase
    {
        private readonly BeautySaloonContext _context;

        public ServiceCategoryesController(BeautySaloonContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCategoryes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategoryes>>> GetServiceCategoryes()
        {
            return await _context.ServiceCategoryes.ToListAsync();
        }

        // GET: api/ServiceCategoryes/5
        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<ServiceCategoryes>> GetServiceCategoryes(int id)
        {
            var serviceCategoryes = await _context.ServiceCategoryes.FindAsync(id);

            if (serviceCategoryes == null)
            {
                return NotFound();
            }

            return serviceCategoryes;
        }

        // PUT: api/ServiceCategoryes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCategorye(int id, ServiceCategoryes serviceCategorye)
        {
            if (id != serviceCategorye.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(serviceCategorye).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCategoryeExists(id))
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

        // POST: api/ServiceCategoryes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceCategoryes>> PostServiceCategorye(ServiceCategoryes serviceCategorye)
        {
            _context.ServiceCategoryes.Add(serviceCategorye);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceCategorye", new { id = serviceCategorye.CategoryId }, serviceCategorye);
        }

        // DELETE: api/ServiceCategoryes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCategorye(int id)
        {
            var serviceCategorye = await _context.ServiceCategoryes.FindAsync(id);
            if (serviceCategorye == null)
            {
                return NotFound();
            }

            _context.ServiceCategoryes.Remove(serviceCategorye);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceCategoryeExists(int id)
        {
            return _context.ServiceCategoryes.Any(e => e.CategoryId == id);
        }
    }
}
