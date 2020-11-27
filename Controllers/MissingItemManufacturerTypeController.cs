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
    public class MissingItemManufacturerTypeController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemManufacturerTypeController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemManufacturerType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemManufacturerType>>> GetMissingItemManufacturerTypes()
        {
            return await _context.MissingItemManufacturerTypes.ToListAsync();
        }

        // GET: api/MissingItemManufacturerType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemManufacturerType>> GetMissingItemManufacturerType(int id)
        {
            var missingItemManufacturerType = await _context.MissingItemManufacturerTypes.FindAsync(id);

            if (missingItemManufacturerType == null)
            {
                return NotFound();
            }

            return missingItemManufacturerType;
        }

        // PUT: api/MissingItemManufacturerType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemManufacturerType(int id, MissingItemManufacturerType missingItemManufacturerType)
        {
            if (id != missingItemManufacturerType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(missingItemManufacturerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemManufacturerTypeExists(id))
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

        // POST: api/MissingItemManufacturerType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemManufacturerType>> PostMissingItemManufacturerType(MissingItemManufacturerType missingItemManufacturerType)
        {
            _context.MissingItemManufacturerTypes.Add(missingItemManufacturerType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MissingItemManufacturerTypeExists(missingItemManufacturerType.TypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMissingItemManufacturerType", new { id = missingItemManufacturerType.TypeId }, missingItemManufacturerType);
        }

        // DELETE: api/MissingItemManufacturerType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemManufacturerType(int id)
        {
            var missingItemManufacturerType = await _context.MissingItemManufacturerTypes.FindAsync(id);
            if (missingItemManufacturerType == null)
            {
                return NotFound();
            }

            _context.MissingItemManufacturerTypes.Remove(missingItemManufacturerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemManufacturerTypeExists(int id)
        {
            return _context.MissingItemManufacturerTypes.Any(e => e.TypeId == id);
        }
    }
}
