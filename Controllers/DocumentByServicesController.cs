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
    public class DocumentByServicesController : ControllerBase
    {
        private readonly BeautySaloonContext _context;

        public DocumentByServicesController(BeautySaloonContext context)
        {
            _context = context;
        }

        // GET: api/DocumentByServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentByService>>> GetDocumentByServices()
        {
            return await _context.DocumentByServices.ToListAsync();
        }

        // GET: api/DocumentByServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentByService>> GetDocumentByService(int id)
        {
            var documentByService = await _context.DocumentByServices.FindAsync(id);

            if (documentByService == null)
            {
                return NotFound();
            }

            return documentByService;
        }

        // PUT: api/DocumentByServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentByService(int id, DocumentByService documentByService)
        {
            if (id != documentByService.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentByService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentByServiceExists(id))
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

        // POST: api/DocumentByServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentByService>> PostDocumentByService(DocumentByService documentByService)
        {
            _context.DocumentByServices.Add(documentByService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentByService", new { id = documentByService.Id }, documentByService);
        }

        // DELETE: api/DocumentByServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentByService(int id)
        {
            var documentByService = await _context.DocumentByServices.FindAsync(id);
            if (documentByService == null)
            {
                return NotFound();
            }

            _context.DocumentByServices.Remove(documentByService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentByServiceExists(int id)
        {
            return _context.DocumentByServices.Any(e => e.Id == id);
        }
    }
}
