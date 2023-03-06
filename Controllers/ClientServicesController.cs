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
    public class ClientServicesController : ControllerBase
    {
        private readonly BeautySaloonContext _context;

        public ClientServicesController(BeautySaloonContext context)
        {
            _context = context;
        }

        // GET: api/ClientServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientService>>> GetClientServices()
        {
            return await _context.ClientServices.ToListAsync();
        }

        // GET: api/ClientServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientService>> GetClientService(int id)
        {
            var clientService = await _context.ClientServices.FindAsync(id);

            if (clientService == null)
            {
                return NotFound();
            }

            return clientService;
        }

        // PUT: api/ClientServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientService(int id, ClientService clientService)
        {
            if (id != clientService.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientServiceExists(id))
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

        // POST: api/ClientServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientService>> PostClientService(ClientService clientService)
        {
            _context.ClientServices.Add(clientService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientService", new { id = clientService.Id }, clientService);
        }

        // DELETE: api/ClientServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientService(int id)
        {
            var clientService = await _context.ClientServices.FindAsync(id);
            if (clientService == null)
            {
                return NotFound();
            }

            _context.ClientServices.Remove(clientService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientServiceExists(int id)
        {
            return _context.ClientServices.Any(e => e.Id == id);
        }
    }
}
