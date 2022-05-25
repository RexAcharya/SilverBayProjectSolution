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
    public class WorkSheetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkSheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkSheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkSheetModel>>> GetWorkSheets()
        {
            return await _context.WorkSheets.ToListAsync();
        }

        // GET: api/WorkSheet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkSheetModel>> GetWorkSheetModel(int id)
        {
            var workSheetModel = await _context.WorkSheets.FindAsync(id);

            if (workSheetModel == null)
            {
                return NotFound();
            }

            return workSheetModel;
        }

        // PUT: api/WorkSheet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkSheetModel(int id, WorkSheetModel workSheetModel)
        {
            if (id != workSheetModel.WorkSheetId)
            {
                return BadRequest();
            }

            _context.Entry(workSheetModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkSheetModelExists(id))
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

        // POST: api/WorkSheet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkSheetModel>> PostWorkSheetModel(WorkSheetModel workSheetModel)
        {
            _context.WorkSheets.Add(workSheetModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkSheetModel", new { id = workSheetModel.WorkSheetId }, workSheetModel);
        }

        // DELETE: api/WorkSheet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkSheetModel(int id)
        {
            var workSheetModel = await _context.WorkSheets.FindAsync(id);
            if (workSheetModel == null)
            {
                return NotFound();
            }

            _context.WorkSheets.Remove(workSheetModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkSheetModelExists(int id)
        {
            return _context.WorkSheets.Any(e => e.WorkSheetId == id);
        }
    }
}
