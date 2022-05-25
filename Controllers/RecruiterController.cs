using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilvarBayAPI.Models;

namespace SilvarBayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecruiterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Recruiter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecruiterModel>>> GetRecruiters()
        {
            return await _context.Recruiters.ToListAsync();
        }

        // GET: api/Recruiter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecruiterModel>> GetRecruiterModel(int id)
        {
            var recruiterModel = await _context.Recruiters.FindAsync(id);

            if (recruiterModel == null)
            {
                return NotFound();
            }

            return recruiterModel;
        }

        // PUT: api/Recruiter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecruiterModel(int id, RecruiterModel recruiterModel)
        {
            if (id != recruiterModel.RecruiterId)
            {
                return BadRequest();
            }

            _context.Entry(recruiterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruiterModelExists(id))
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

        // POST: api/Recruiter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecruiterModel>> PostRecruiterModel(RecruiterModel recruiterModel)
        {
            _context.Recruiters.Add(recruiterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecruiterModel", new { id = recruiterModel.RecruiterId }, recruiterModel);
        }

        // DELETE: api/Recruiter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecruiterModel(int id)
        {
            var recruiterModel = await _context.Recruiters.FindAsync(id);
            if (recruiterModel == null)
            {
                return NotFound();
            }

            _context.Recruiters.Remove(recruiterModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecruiterModelExists(int id)
        {
            return _context.Recruiters.Any(e => e.RecruiterId == id);
        }
    }
}
