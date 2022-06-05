using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityHomework.Context;
using UniversityHomework.Models;

namespace UniversityHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionsController : ControllerBase
    {
        private readonly HomeworkContext _context;

        public DescriptionsController(HomeworkContext context)
        {
            _context = context;
        }

        // GET: api/Descriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
          if (_context.Descriptions == null)
          {
              return NotFound();
          }
            return await _context.Descriptions.ToListAsync();
        }

        // GET: api/Descriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescription(Guid id)
        {
          if (_context.Descriptions == null)
          {
              return NotFound();
          }
            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Descriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription(Guid id, Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _context.Entry(description).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptionExists(id))
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

        // POST: api/Descriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Description>> PostDescription(Description description)
        {
          if (_context.Descriptions == null)
          {
              return Problem("Entity set 'HomeworkContext.Descriptions'  is null.");
          }
            _context.Descriptions.Add(description);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescription", new { id = description.Id }, description);
        }

        // DELETE: api/Descriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescription(Guid id)
        {
            if (_context.Descriptions == null)
            {
                return NotFound();
            }
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescriptionExists(Guid id)
        {
            return (_context.Descriptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
