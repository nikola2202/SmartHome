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
    public class StringParametersController : ControllerBase
    {
        private readonly SmartHomeDBContext _context;

        public StringParametersController(SmartHomeDBContext context)
        {
            _context = context;
        }

        // GET: api/StringParameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StringParameter>>> GetStringParameter()
        {
            return await _context.StringParameter.ToListAsync();
        }

        // GET: api/StringParameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StringParameter>> GetStringParameter(long id)
        {
            var stringParameter = await _context.StringParameter.FindAsync(id);

            if (stringParameter == null)
            {
                return NotFound();
            }

            return stringParameter;
        }

        // PUT: api/StringParameters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStringParameter(long id, StringParameter stringParameter)
        {
            if (id != stringParameter.StringParameterId)
            {
                return BadRequest();
            }

            _context.Entry(stringParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StringParameterExists(id))
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

        // POST: api/StringParameters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StringParameter>> PostStringParameter(StringParameter stringParameter)
        {
            _context.StringParameter.Add(stringParameter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStringParameter), new { id = stringParameter.StringParameterId }, stringParameter);
        }

        // DELETE: api/StringParameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StringParameter>> DeleteStringParameter(long id)
        {
            var stringParameter = await _context.StringParameter.FindAsync(id);
            if (stringParameter == null)
            {
                return NotFound();
            }

            _context.StringParameter.Remove(stringParameter);
            await _context.SaveChangesAsync();

            return stringParameter;
        }

        private bool StringParameterExists(long id)
        {
            return _context.StringParameter.Any(e => e.StringParameterId == id);
        }
    }
}
