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
    public class ArtisteController : ControllerBase
    {
        private readonly MySQLContext _context;

        public ArtisteController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Artiste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtisteItem>>> GetArtisteItems()
        {
            return await _context.ArtisteItems.ToListAsync();
        }

        // GET: api/Artiste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtisteItem>> GetArtisteItem(long id)
        {
            var artisteItem = await _context.ArtisteItems.FindAsync(id);

            if (artisteItem == null)
            {
                return NotFound();
            }

            return artisteItem;
        }

        // PUT: api/Artiste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtisteItem(long id, ArtisteItem artisteItem)
        {
            if (id != artisteItem.id)
            {
                return BadRequest();
            }

            _context.Entry(artisteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtisteItemExists(id))
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

        // POST: api/Artiste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtisteItem>> PostArtisteItem(ArtisteItem artisteItem)
        {
            _context.ArtisteItems.Add(artisteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtisteItem", new { id = artisteItem.id }, artisteItem);
        }

        // DELETE: api/Artiste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtisteItem(long id)
        {
            var artisteItem = await _context.ArtisteItems.FindAsync(id);
            if (artisteItem == null)
            {
                return NotFound();
            }

            _context.ArtisteItems.Remove(artisteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/get")]
        public async Task<IActionResult> GetDetailArtist(long id)
        {
            try
            {
                // Récupérer l'artiste en fonction de l'ID
                var artiste = await _context.ArtisteItems.FindAsync(id);

                if (artiste == null)
                {
                    return NotFound(new { message = $"Aucun artiste trouvé avec l'ID {id}." });
                }

                return Ok(new { data = artiste });
            }
            catch (Exception ex)
            {
                // Gérer les erreurs et renvoyer un message approprié
                Console.Error.WriteLine(ex);
                return StatusCode(500, new { message = "Une erreur s'est produite lors de la récupération des données de l'artiste.", error = ex.Message });
            }
        }

        [HttpGet("{id}/morceaux")]
        public async Task<IActionResult> GetArtistSongs(long id)
        {
            try
            {
                // Récupérer les morceaux associés à l'artiste
                var morceaux = await _context.morceaux
                    .Where(m => m.ArtisteId == id)
                    .ToListAsync();

                if (morceaux == null || !morceaux.Any())
                {
                    return NotFound(new { message = $"Aucun morceau trouvé pour l'artiste avec l'ID {id}." });
                }

                return Ok(new { data = morceaux });
            }
            catch (Exception ex)
            {
                // Gérer les erreurs et renvoyer un message approprié
                Console.Error.WriteLine(ex);
                return StatusCode(500, new { message = "Une erreur s'est produite lors de la récupération des chansons de l'artiste.", error = ex.Message });
            }
        }

        private bool ArtisteItemExists(long id)
        {
            return _context.ArtisteItems.Any(e => e.id == id);
        }
    }
}
