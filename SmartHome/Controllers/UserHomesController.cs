using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.DBContexts;
using SmartHome.Models;

namespace SmartHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHomesController : ControllerBase
    {
        private readonly SmartHomeDBContext _context;

        public UserHomesController(SmartHomeDBContext context)
        {
            _context = context;
        }

        // GET: api/UserHomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHome>>> GetUserHomes()
        {
            return await _context.UserHomes.ToListAsync();
        }

        // GET: api/UserHomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHome>> GetUserHome(long id)
        {
            var userHome = await _context.UserHomes.FindAsync(id);

            if (userHome == null)
            {
                return NotFound();
            }

            return userHome;
        }

        // PUT: api/UserHomes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHome(long id, UserHome userHome)
        {
            if (id != userHome.Id)
            {
                return BadRequest();
            }

            _context.Entry(userHome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHomeExists(id))
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

        // POST: api/UserHomes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserHome>> PostUserHome(UserHome userHome)
        {
            _context.UserHomes.Add(userHome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserHome", new { id = userHome.Id }, userHome);
        }

        // DELETE: api/UserHomes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserHome>> DeleteUserHome(long id)
        {
            var userHome = await _context.UserHomes.FindAsync(id);
            if (userHome == null)
            {
                return NotFound();
            }

            _context.UserHomes.Remove(userHome);
            await _context.SaveChangesAsync();

            return userHome;
        }

        private bool UserHomeExists(long id)
        {
            return _context.UserHomes.Any(e => e.Id == id);
        }
    }
}
