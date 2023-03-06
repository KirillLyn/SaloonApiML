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
    public class ServicePhotoesController : ControllerBase
    {
        private readonly BeautySaloonContext _context;

        public ServicePhotoesController(BeautySaloonContext context)
        {
            _context = context;
        }

        // GET: api/ServicePhotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicePhoto>>> GetServicePhotos()
        {
            return await _context.ServicePhotos.ToListAsync();
        }

        // GET: api/ServicePhotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicePhoto>> GetServicePhoto(int id)
        {
            var servicePhoto = await _context.ServicePhotos.FindAsync(id);

            if (servicePhoto == null)
            {
                return NotFound();
            }

            return servicePhoto;
        }

        // PUT: api/ServicePhotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicePhoto(int id, ServicePhoto servicePhoto)
        {
            if (id != servicePhoto.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicePhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePhotoExists(id))
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

        // POST: api/ServicePhotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicePhoto>> PostServicePhoto(ServicePhoto servicePhoto)
        {
            _context.ServicePhotos.Add(servicePhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicePhoto", new { id = servicePhoto.Id }, servicePhoto);
        }

        // DELETE: api/ServicePhotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicePhoto(int id)
        {
            var servicePhoto = await _context.ServicePhotos.FindAsync(id);
            if (servicePhoto == null)
            {
                return NotFound();
            }

            _context.ServicePhotos.Remove(servicePhoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicePhotoExists(int id)
        {
            return _context.ServicePhotos.Any(e => e.Id == id);
        }
    }
}
