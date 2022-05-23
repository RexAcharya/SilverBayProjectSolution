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
    public class VendorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorModel>>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorModel>> GetVendorModel(int id)
        {
            var vendorModel = await _context.Vendors.FindAsync(id);

            if (vendorModel == null)
            {
                return NotFound();
            }

            return vendorModel;
        }

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorModel(int id, VendorModel vendorModel)
        {
            if (id != vendorModel.VendorId)
            {
                return BadRequest();
            }

            _context.Entry(vendorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorModelExists(id))
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

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorModel>> PostVendorModel(VendorModel vendorModel)
        {
            _context.Vendors.Add(vendorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorModel", new { id = vendorModel.VendorId }, vendorModel);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorModel(int id)
        {
            var vendorModel = await _context.Vendors.FindAsync(id);
            if (vendorModel == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorModelExists(int id)
        {
            return _context.Vendors.Any(e => e.VendorId== id);
        }
    }
}
