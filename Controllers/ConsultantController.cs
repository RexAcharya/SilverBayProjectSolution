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
    public class ConsultantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsultantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultantModel>>> GetConsultants()
        {
            return await _context.Consultants.ToListAsync();
        }

        // GET: api/Consultant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultantModel>> GetConsultantModel(string id)
        {
            var consultantModel = await _context.Consultants.FindAsync(id);

            if (consultantModel == null)
            {
                return NotFound();
            }

            return consultantModel;
        }

        // PUT: api/Consultant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultantModel(string id, ConsultantModel consultantModel)
        {
            if (id != consultantModel.consultantId)
            {
                return BadRequest();
            }

            _context.Entry(consultantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantModelExists(id))
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

        // POST: api/Consultant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsultantModel>> PostConsultantModel(ConsultantModel consultantModel)
        {
            _context.Consultants.Add(consultantModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultantModel", new { id = consultantModel.consultantId }, consultantModel);
        }

        // DELETE: api/Consultant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultantModel(string id)
        {
            var consultantModel = await _context.Consultants.FindAsync(id);
            if (consultantModel == null)
            {
                return NotFound();
            }

            _context.Consultants.Remove(consultantModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultantModelExists(string id)
        {
            return _context.Consultants.Any(e => e.consultantId == id);
        }
    }
}
