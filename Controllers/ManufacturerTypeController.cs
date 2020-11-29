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
    public class ManufacturerTypeController : ControllerBase
    {
        private readonly MissingReportsContext _context;

        public ManufacturerTypeController(MissingReportsContext context)
        {
            _context = context;
        }

        // GET: api/ManufacturerType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerType>>> GetManufacturerTypes()
        {
            return await _context.ManufacturerTypes.ToListAsync();
        }

        // GET: api/ManufacturerType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerType>> GetManufacturerType(Guid id)
        {
            var manufacturerType = await _context.ManufacturerTypes.FindAsync(id);

            if (manufacturerType == null)
            {
                return NotFound();
            }

            return manufacturerType;
        }

        // PUT: api/ManufacturerType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturerType(Guid id, ManufacturerType manufacturerType)
        {
            if (id != manufacturerType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(manufacturerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerTypeExists(id))
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

        // POST: api/ManufacturerType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManufacturerType>> PostManufacturerType(ManufacturerType manufacturerType)
        {
            _context.ManufacturerTypes.Add(manufacturerType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ManufacturerTypeExists(manufacturerType.TypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetManufacturerType", new { id = manufacturerType.TypeId }, manufacturerType);
        }

        // DELETE: api/ManufacturerType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturerType(Guid id)
        {
            var manufacturerType = await _context.ManufacturerTypes.FindAsync(id);
            if (manufacturerType == null)
            {
                return NotFound();
            }

            _context.ManufacturerTypes.Remove(manufacturerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerTypeExists(Guid id)
        {
            return _context.ManufacturerTypes.Any(e => e.TypeId == id);
        }
    }
}
