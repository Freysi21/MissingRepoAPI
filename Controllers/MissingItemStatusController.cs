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
    public class MissingItemStatusController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemStatusController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemStatus>>> GetMissingItemStatuses()
        {
            return await _context.MissingItemStatuses.ToListAsync();
        }

        // GET: api/MissingItemStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemStatus>> GetMissingItemStatus(int id)
        {
            var missingItemStatus = await _context.MissingItemStatuses.FindAsync(id);

            if (missingItemStatus == null)
            {
                return NotFound();
            }

            return missingItemStatus;
        }

        // PUT: api/MissingItemStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemStatus(int id, MissingItemStatus missingItemStatus)
        {
            if (id != missingItemStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(missingItemStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemStatusExists(id))
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

        // POST: api/MissingItemStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemStatus>> PostMissingItemStatus(MissingItemStatus missingItemStatus)
        {
            _context.MissingItemStatuses.Add(missingItemStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissingItemStatus", new { id = missingItemStatus.Id }, missingItemStatus);
        }

        // DELETE: api/MissingItemStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemStatus(int id)
        {
            var missingItemStatus = await _context.MissingItemStatuses.FindAsync(id);
            if (missingItemStatus == null)
            {
                return NotFound();
            }

            _context.MissingItemStatuses.Remove(missingItemStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemStatusExists(int id)
        {
            return _context.MissingItemStatuses.Any(e => e.Id == id);
        }
    }
}
