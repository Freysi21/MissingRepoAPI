using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporterController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public ReporterController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/Reporter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporter>>> GetReporters()
        {
            return await _context.Reporters.ToListAsync();
        }

        // GET: api/Reporter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reporter>> GetReporter(int id)
        {
            var reporter = await _context.Reporters.FindAsync(id);

            if (reporter == null)
            {
                return NotFound();
            }

            return reporter;
        }

        // PUT: api/Reporter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporter(int id, Reporter reporter)
        {
            if (id != reporter.Id)
            {
                return BadRequest();
            }

            _context.Entry(reporter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporterExists(id))
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

        // POST: api/Reporter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reporter>> PostReporter(Reporter reporter)
        {
            _context.Reporters.Add(reporter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReporter", new { id = reporter.Id }, reporter);
        }

        // DELETE: api/Reporter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporter(int id)
        {
            var reporter = await _context.Reporters.FindAsync(id);
            if (reporter == null)
            {
                return NotFound();
            }

            _context.Reporters.Remove(reporter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReporterExists(int id)
        {
            return _context.Reporters.Any(e => e.Id == id);
        }
    }
}
