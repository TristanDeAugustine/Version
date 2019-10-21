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
    public class TodoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TodoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodoModel()
        {
            return await _context.TodoModel.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoModel(int id)
        {
            var todoModel = await _context.TodoModel.FindAsync(id);

            if (todoModel == null)
            {
                return NotFound();
            }

            return todoModel;
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoModel(int id, TodoModel todoModel)
        {
            if (id != todoModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(todoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoModelExists(id))
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

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<TodoModel>> PostTodoModel(TodoModel todoModel)
        {
            _context.TodoModel.Add(todoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoModel", new { id = todoModel.ID }, todoModel);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoModel>> DeleteTodoModel(int id)
        {
            var todoModel = await _context.TodoModel.FindAsync(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            _context.TodoModel.Remove(todoModel);
            await _context.SaveChangesAsync();

            return todoModel;
        }

        private bool TodoModelExists(int id)
        {
            return _context.TodoModel.Any(e => e.ID == id);
        }
    }
}
