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
    public class DeviceParameterCurrentValuesController : ControllerBase
    {
        private readonly SmartHomeDBContext _context;

        public DeviceParameterCurrentValuesController(SmartHomeDBContext context)
        {
            _context = context;
        }

        // GET: api/DeviceParameterCurrentValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceParameterCurrentValue>>> GetDeviceParameterCurrentValue()
        {
            return await _context.DeviceParameterCurrentValue.ToListAsync();
        }

        // GET: api/DeviceParameterCurrentValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceParameterCurrentValue>> GetDeviceParameterCurrentValue(long id)
        {
            var deviceParameterCurrentValue = await _context.DeviceParameterCurrentValue.FindAsync(id);

            if (deviceParameterCurrentValue == null)
            {
                return NotFound();
            }

            return deviceParameterCurrentValue;
        }

        // PUT: api/DeviceParameterCurrentValues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceParameterCurrentValue(long id, DeviceParameterCurrentValue deviceParameterCurrentValue)
        {
            if (id != deviceParameterCurrentValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(deviceParameterCurrentValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceParameterCurrentValueExists(id))
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

        // POST: api/DeviceParameterCurrentValues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeviceParameterCurrentValue>> PostDeviceParameterCurrentValue(DeviceParameterCurrentValue deviceParameterCurrentValue)
        {
            _context.DeviceParameterCurrentValue.Add(deviceParameterCurrentValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeviceParameterCurrentValue), new { id = deviceParameterCurrentValue.Id }, deviceParameterCurrentValue);
        }

        // DELETE: api/DeviceParameterCurrentValues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeviceParameterCurrentValue>> DeleteDeviceParameterCurrentValue(long id)
        {
            var deviceParameterCurrentValue = await _context.DeviceParameterCurrentValue.FindAsync(id);
            if (deviceParameterCurrentValue == null)
            {
                return NotFound();
            }

            _context.DeviceParameterCurrentValue.Remove(deviceParameterCurrentValue);
            await _context.SaveChangesAsync();

            return deviceParameterCurrentValue;
        }

        private bool DeviceParameterCurrentValueExists(long id)
        {
            return _context.DeviceParameterCurrentValue.Any(e => e.Id == id);
        }
    }
}
