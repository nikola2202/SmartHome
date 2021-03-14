using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHome.DBContexts;
using SmartHome.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private SmartHomeDBContext myDbContext;

        public HomesController(SmartHomeDBContext context)
        {
            myDbContext = context;
        }


        // GET: api/Homes
        [HttpGet]
        public IList<Home> Get()
        {
            return (this.myDbContext.Homes.ToList());
        }


        // GET: api/Homes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Home>> GetHome(long id)
        {
            var home = await myDbContext.Homes.FindAsync(id);

            if (home == null)
            {
                return NotFound();
            }

            return home;
        }


        // PUT: api/Homes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(long id, Home home)
        {
            if (id != home.Id)
            {
                return BadRequest();
            }

            myDbContext.Entry(home).State = EntityState.Modified;
            
            try
            {
                await myDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
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


        // POST: api/Homes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Home>> PostHome(Home home)
        {
            myDbContext.Homes.Add(home);
            await myDbContext.SaveChangesAsync();

            //return CreatedAtAction("GetHome", new { id = home.id }, home);
            return CreatedAtAction(nameof(GetHome), new { id = home.Id }, home);
        }


        // DELETE: api/Homes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Home>> DeleteHome(long id)
        {
            var home = await myDbContext.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }

            myDbContext.Homes.Remove(home);
            await myDbContext.SaveChangesAsync();

            return home;
        }
        private bool HomeExists(long id)
        {
            return myDbContext.Homes.Any(e => e.Id == id);
        }
    }
}