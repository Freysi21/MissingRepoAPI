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
    public class MissingItemReportCommentController : ControllerBase
    {
        private readonly MissingItemReportsContext _context;

        public MissingItemReportCommentController(MissingItemReportsContext context)
        {
            _context = context;
        }

        // GET: api/MissingItemReportComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissingItemReportComment>>> GetMissingItemReportComments()
        {
            return await _context.MissingItemReportComments.ToListAsync();
        }

        // GET: api/MissingItemReportComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissingItemReportComment>> GetMissingItemReportComment(int id)
        {
            var missingItemReportComment = await _context.MissingItemReportComments.FindAsync(id);

            if (missingItemReportComment == null)
            {
                return NotFound();
            }

            return missingItemReportComment;
        }

        // PUT: api/MissingItemReportComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissingItemReportComment(int id, MissingItemReportComment missingItemReportComment)
        {
            if (id != missingItemReportComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(missingItemReportComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissingItemReportCommentExists(id))
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

        // POST: api/MissingItemReportComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissingItemReportComment>> PostMissingItemReportComment(MissingItemReportComment missingItemReportComment)
        {
            _context.MissingItemReportComments.Add(missingItemReportComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissingItemReportComment", new { id = missingItemReportComment.Id }, missingItemReportComment);
        }

        // DELETE: api/MissingItemReportComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissingItemReportComment(int id)
        {
            var missingItemReportComment = await _context.MissingItemReportComments.FindAsync(id);
            if (missingItemReportComment == null)
            {
                return NotFound();
            }

            _context.MissingItemReportComments.Remove(missingItemReportComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissingItemReportCommentExists(int id)
        {
            return _context.MissingItemReportComments.Any(e => e.Id == id);
        }
    }
}
