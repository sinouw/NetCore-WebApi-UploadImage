using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadImage.Models;

namespace UploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StadiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stadia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadiums()
        {
            return await _context.Stadiums
                .Include(s=>s.Images)
                .ToListAsync();
        }

        // GET: api/Stadia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadium(int id)
        {
            var stadium = await _context.Stadiums
                .Include(s => s.Images)
                .SingleOrDefaultAsync(s=>s.IdStadium==id);

            if (stadium == null)
            {
                return NotFound();
            }

            return stadium;
        }

        // PUT: api/Stadia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStadium(int id, Stadium stadium)
        {
            if (id != stadium.IdStadium)
            {
                return BadRequest();
            }

            _context.Entry(stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(id))
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

        // POST: api/Stadia
        [HttpPost]
        public async Task<ActionResult<Stadium>> PostStadium(Stadium stadium)
        {
            _context.Stadiums.Add(stadium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStadium", new { id = stadium.IdStadium }, stadium);
        }

        // DELETE: api/Stadia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stadium>> DeleteStadium(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();

            return stadium;
        }

        private bool StadiumExists(int id)
        {
            return _context.Stadiums.Any(e => e.IdStadium == id);
        }
    }
}
