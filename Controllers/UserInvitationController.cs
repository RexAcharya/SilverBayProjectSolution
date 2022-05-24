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
    public class UserInvitationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserInvitationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInvitation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInvitationModel>>> GetUserInvitations()
        {
            return await _context.UserInvitations.ToListAsync();
        }

        // GET: api/UserInvitation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInvitationModel>> GetUserInvitationModel(int id)
        {
            var userInvitationModel = await _context.UserInvitations.FindAsync(id);

            if (userInvitationModel == null)
            {
                return NotFound();
            }

            return userInvitationModel;
        }

        // PUT: api/UserInvitation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInvitationModel(int id, UserInvitationModel userInvitationModel)
        {
            if (id != userInvitationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInvitationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInvitationModelExists(id))
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

        // POST: api/UserInvitation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInvitationModel>> PostUserInvitationModel(UserInvitationModel userInvitationModel)
        {
            _context.UserInvitations.Add(userInvitationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInvitationModel", new { id = userInvitationModel.Id }, userInvitationModel);
        }

        // DELETE: api/UserInvitation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInvitationModel(int id)
        {
            var userInvitationModel = await _context.UserInvitations.FindAsync(id);
            if (userInvitationModel == null)
            {
                return NotFound();
            }

            _context.UserInvitations.Remove(userInvitationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInvitationModelExists(int id)
        {
            return _context.UserInvitations.Any(e => e.Id == id);
        }
    }
}
