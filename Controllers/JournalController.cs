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
    public class JournalController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public JournalController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Journal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalModel>>> GetJournalModel()
        {
            return await _context.JournalModel.ToListAsync();
        }

        // GET: api/Journal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalModel>> GetJournalModel(int id)
        {
            var journalModel = await _context.JournalModel.FindAsync(id);

            if (journalModel == null)
            {
                return NotFound();
            }

            return journalModel;
        }

        // PUT: api/Journal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournalModel(int id, JournalModel journalModel)
        {
            if (id != journalModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(journalModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalModelExists(id))
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

        // POST: api/Journal
        [HttpPost]
        public async Task<ActionResult<JournalModel>> PostJournalModel(JournalModel journalModel)
        {
            _context.JournalModel.Add(journalModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournalModel", new { id = journalModel.ID }, journalModel);
        }

        // DELETE: api/Journal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JournalModel>> DeleteJournalModel(int id)
        {
            var journalModel = await _context.JournalModel.FindAsync(id);
            if (journalModel == null)
            {
                return NotFound();
            }

            _context.JournalModel.Remove(journalModel);
            await _context.SaveChangesAsync();

            return journalModel;
        }

        private bool JournalModelExists(int id)
        {
            return _context.JournalModel.Any(e => e.ID == id);
        }
    }
}
