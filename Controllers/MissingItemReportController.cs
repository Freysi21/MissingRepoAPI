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
    public class MissingItemReportController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemReportController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemReport>>> GetMissingItemReports()
        {
            return await _context.MissingItemReports.ToListAsync();
        }

        // GET: api/MissingItemReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemReport>> GetMissingItemReport(int id)
        {
            var missingItemReport = await _context.MissingItemReports.FindAsync(id);

            if (missingItemReport == null)
            {
                return NotFound();
            }

            return missingItemReport;
        }

        // PUT: api/MissingItemReport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemReport(int id, MissingItemReport missingItemReport)
        {
            if (id != missingItemReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(missingItemReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemReportExists(id))
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

        // POST: api/MissingItemReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemReport>> PostMissingItemReport(MissingItemReport missingItemReport)
        {
            _context.MissingItemReports.Add(missingItemReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissingItemReport", new { id = missingItemReport.Id }, missingItemReport);
        }

        // DELETE: api/MissingItemReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemReport(int id)
        {
            var missingItemReport = await _context.MissingItemReports.FindAsync(id);
            if (missingItemReport == null)
            {
                return NotFound();
            }

            _context.MissingItemReports.Remove(missingItemReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemReportExists(int id)
        {
            return _context.MissingItemReports.Any(e => e.Id == id);
        }
    }
}
