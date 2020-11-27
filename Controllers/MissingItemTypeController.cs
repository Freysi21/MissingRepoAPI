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
    public class MissingItemTypeController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemTypeController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemType>>> GetMissingItemTypes()
        {
            return await _context.MissingItemTypes.ToListAsync();
        }

        // GET: api/MissingItemType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemType>> GetMissingItemType(int id)
        {
            var missingItemType = await _context.MissingItemTypes.FindAsync(id);

            if (missingItemType == null)
            {
                return NotFound();
            }

            return missingItemType;
        }

        // PUT: api/MissingItemType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemType(int id, MissingItemType missingItemType)
        {
            if (id != missingItemType.Id)
            {
                return BadRequest();
            }

            _context.Entry(missingItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemTypeExists(id))
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

        // POST: api/MissingItemType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemType>> PostMissingItemType(MissingItemType missingItemType)
        {
            _context.MissingItemTypes.Add(missingItemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissingItemType", new { id = missingItemType.Id }, missingItemType);
        }

        // DELETE: api/MissingItemType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemType(int id)
        {
            var missingItemType = await _context.MissingItemTypes.FindAsync(id);
            if (missingItemType == null)
            {
                return NotFound();
            }

            _context.MissingItemTypes.Remove(missingItemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemTypeExists(int id)
        {
            return _context.MissingItemTypes.Any(e => e.Id == id);
        }
    }
}
