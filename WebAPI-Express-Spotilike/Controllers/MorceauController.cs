using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Express_Spotilike.Models;

namespace WebAPI_Express_Spotilike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorceauController : ControllerBase
    {
        private readonly MySQLContext _context;

        public MorceauController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Morceau
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MorceauItem>>> Getmorceaux()
        {
            return await _context.morceaux.ToListAsync();
        }

        // GET: api/Morceau/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MorceauItem>> GetMorceauItem(long id)
        {
            var morceauItem = await _context.morceaux.FindAsync(id);

            if (morceauItem == null)
            {
                return NotFound();
            }

            return morceauItem;
        }

        // PUT: api/Morceau/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMorceauItem(long id, MorceauItem morceauItem)
        {
            if (id != morceauItem.id)
            {
                return BadRequest();
            }

            _context.Entry(morceauItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MorceauItemExists(id))
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

        // POST: api/Morceau
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MorceauItem>> PostMorceauItem(MorceauItem morceauItem)
        {
            _context.morceaux.Add(morceauItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMorceauItem", new { id = morceauItem.id }, morceauItem);
        }

        // DELETE: api/Morceau/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMorceauItem(long id)
        {
            var morceauItem = await _context.morceaux.FindAsync(id);
            if (morceauItem == null)
            {
                return NotFound();
            }

            _context.morceaux.Remove(morceauItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MorceauItemExists(long id)
        {
            return _context.morceaux.Any(e => e.id == id);
        }
    }
}
