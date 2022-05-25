using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilvarBayAPI.Models;

namespace SilvarBayAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientVendorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientVendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientVendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client_VendorModel>>> GetClientAndVendors()
        {
            return await _context.ClientAndVendors.ToListAsync();
        }

        // GET: api/ClientVendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client_VendorModel>> GetClient_VendorModel(int id)
        {
            var client_VendorModel = await _context.ClientAndVendors.FindAsync(id);

            if (client_VendorModel == null)
            {
                return NotFound();
            }

            return client_VendorModel;
        }

        // PUT: api/ClientVendor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient_VendorModel(int id, Client_VendorModel client_VendorModel)
        {
            if (id != client_VendorModel.ClientVendorId)
            {
                return BadRequest();
            }

            _context.Entry(client_VendorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_VendorModelExists(id))
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

        // POST: api/ClientVendor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client_VendorModel>> PostClient_VendorModel(Client_VendorModel client_VendorModel)
        {
            _context.ClientAndVendors.Add(client_VendorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient_VendorModel", new { id = client_VendorModel.ClientVendorId }, client_VendorModel);
        }

        // DELETE: api/ClientVendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient_VendorModel(int id)
        {
            var client_VendorModel = await _context.ClientAndVendors.FindAsync(id);
            if (client_VendorModel == null)
            {
                return NotFound();
            }

            _context.ClientAndVendors.Remove(client_VendorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Client_VendorModelExists(int id)
        {
            return _context.ClientAndVendors.Any(e => e.ClientVendorId == id);
        }
    }
}
