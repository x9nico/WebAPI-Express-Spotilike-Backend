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
    public class GenreController : ControllerBase
    {
        private readonly MySQLContext _context;

        public GenreController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreItem>>> GetGenreItem()
        {
            return await _context.GenreItems.ToListAsync();
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreItem>> GetGenreItem(long id)
        {
            var genreItem = await _context.GenreItems.FindAsync(id);

            if (genreItem == null)
            {
                return NotFound();
            }

            return genreItem;
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenreItem(long id, GenreItem genreItem)
        {
            if (id != genreItem.id)
            {
                return BadRequest();
            }

            _context.Entry(genreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreItemExists(id))
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

        // POST: api/Genre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenreItem>> PostGenreItem(GenreItem genreItem)
        {
            _context.GenreItems.Add(genreItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenreItem", new { id = genreItem.id }, genreItem);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreItem(long id)
        {
            var genreItem = await _context.GenreItems.FindAsync(id);
            if (genreItem == null)
            {
                return NotFound();
            }

            _context.GenreItems.Remove(genreItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreItemExists(long id)
        {
            return _context.GenreItems.Any(e => e.id == id);
        }
    }
}
