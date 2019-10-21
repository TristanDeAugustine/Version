using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Version.Models;
using version;

namespace sdg_react_template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CalendarController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Calendar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendar()
        {
            return await _context.Calendar.ToListAsync();
        }

        // GET: api/Calendar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendar>> GetCalendar(int id)
        {
            var calendar = await _context.Calendar.FindAsync(id);

            if (calendar == null)
            {
                return NotFound();
            }

            return calendar;
        }

        // PUT: api/Calendar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendar(int id, Calendar calendar)
        {
            if (id != calendar.ID)
            {
                return BadRequest();
            }

            _context.Entry(calendar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(id))
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

        // POST: api/Calendar
        [HttpPost]
        public async Task<ActionResult<Calendar>> PostCalendar(Calendar calendar)
        {
            _context.Calendar.Add(calendar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendar", new { id = calendar.ID }, calendar);
        }

        // DELETE: api/Calendar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calendar>> DeleteCalendar(int id)
        {
            var calendar = await _context.Calendar.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

            _context.Calendar.Remove(calendar);
            await _context.SaveChangesAsync();

            return calendar;
        }

        private bool CalendarExists(int id)
        {
            return _context.Calendar.Any(e => e.ID == id);
        }
    }
}
