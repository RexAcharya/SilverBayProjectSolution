using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SilvarBayAPI.Models;

namespace SilvarBayAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModelk>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModelk>> GetClientModelk(int id)
        {
            var clientModelk = await _context.Clients.FindAsync(id);

            if (clientModelk == null)
            {
                return NotFound();
            }

            return clientModelk;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientModelk(int id, ClientModelk clientModelk)
        {
            if (id != clientModelk.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clientModelk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientModelkExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientModelk>> PostClientModelk(ClientModelk clientModelk)
        {
            _context.Clients.Add(clientModelk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientModelk", new { id = clientModelk.ClientId }, clientModelk);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientModelk(int id)
        {
            var clientModelk = await _context.Clients.FindAsync(id);
            if (clientModelk == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clientModelk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientModelkExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
