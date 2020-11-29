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
    public class ReportCommentController : ControllerBase
    {
        private readonly MissingReportsContext _context;

        public ReportCommentController(MissingReportsContext context)
        {
            _context = context;
        }

        // GET: api/ReportComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportComment>>> GetReportComments()
        {
            return await _context.ReportComments.ToListAsync();
        }

        // GET: api/ReportComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportComment>> GetReportComment(Guid id)
        {
            var reportComment = await _context.ReportComments.FindAsync(id);

            if (reportComment == null)
            {
                return NotFound();
            }

            return reportComment;
        }

        // PUT: api/ReportComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportComment(Guid id, ReportComment reportComment)
        {
            if (id != reportComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCommentExists(id))
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

        // POST: api/ReportComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportComment>> PostReportComment(ReportComment reportComment)
        {
            _context.ReportComments.Add(reportComment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReportCommentExists(reportComment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReportComment", new { id = reportComment.Id }, reportComment);
        }

        // DELETE: api/ReportComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportComment(Guid id)
        {
            var reportComment = await _context.ReportComments.FindAsync(id);
            if (reportComment == null)
            {
                return NotFound();
            }

            _context.ReportComments.Remove(reportComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportCommentExists(Guid id)
        {
            return _context.ReportComments.Any(e => e.Id == id);
        }
    }
}
