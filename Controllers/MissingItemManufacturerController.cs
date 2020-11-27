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
    public class MissingItemManufacturerController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemManufacturerController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemManufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemManufacturer>>> GetMissingItemManufacturers()
        {
            return await _context.MissingItemManufacturers.ToListAsync();
        }

        // GET: api/MissingItemManufacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemManufacturer>> GetMissingItemManufacturer(int id)
        {
            var missingItemManufacturer = await _context.MissingItemManufacturers.FindAsync(id);

            if (missingItemManufacturer == null)
            {
                return NotFound();
            }

            return missingItemManufacturer;
        }

        // PUT: api/MissingItemManufacturer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemManufacturer(int id, MissingItemManufacturer missingItemManufacturer)
        {
            if (id != missingItemManufacturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(missingItemManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemManufacturerExists(id))
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

        // POST: api/MissingItemManufacturer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemManufacturer>> PostMissingItemManufacturer(MissingItemManufacturer missingItemManufacturer)
        {
            _context.MissingItemManufacturers.Add(missingItemManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissingItemManufacturer", new { id = missingItemManufacturer.Id }, missingItemManufacturer);
        }

        // DELETE: api/MissingItemManufacturer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemManufacturer(int id)
        {
            var missingItemManufacturer = await _context.MissingItemManufacturers.FindAsync(id);
            if (missingItemManufacturer == null)
            {
                return NotFound();
            }

            _context.MissingItemManufacturers.Remove(missingItemManufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemManufacturerExists(int id)
        {
            return _context.MissingItemManufacturers.Any(e => e.Id == id);
        }
    }
}
