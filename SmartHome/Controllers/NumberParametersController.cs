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
    public class NumberParametersController : ControllerBase
    {
        private readonly SmartHomeDBContext _context;

        public NumberParametersController(SmartHomeDBContext context)
        {
            _context = context;
        }

        // GET: api/NumberParameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumberParameter>>> GetNumberParameter()
        {
            return await _context.NumberParameter.ToListAsync();
        }

        // GET: api/NumberParameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumberParameter>> GetNumberParameter(long id)
        {
            var numberParameter = await _context.NumberParameter.FindAsync(id);

            if (numberParameter == null)
            {
                return NotFound();
            }

            return numberParameter;
        }

        // PUT: api/NumberParameters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumberParameter(long id, NumberParameter numberParameter)
        {
            if (id != numberParameter.NumberParameterId)
            {
                return BadRequest();
            }

            _context.Entry(numberParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberParameterExists(id))
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

        // POST: api/NumberParameters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NumberParameter>> PostNumberParameter(NumberParameter numberParameter)
        {
            _context.NumberParameter.Add(numberParameter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNumberParameter), new { id = numberParameter.NumberParameterId }, numberParameter);
        }

        // DELETE: api/NumberParameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NumberParameter>> DeleteNumberParameter(long id)
        {
            var numberParameter = await _context.NumberParameter.FindAsync(id);
            if (numberParameter == null)
            {
                return NotFound();
            }

            _context.NumberParameter.Remove(numberParameter);
            await _context.SaveChangesAsync();

            return numberParameter;
        }

        private bool NumberParameterExists(long id)
        {
            return _context.NumberParameter.Any(e => e.NumberParameterId == id);
        }
    }
}
