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
    public class AlbumController : ControllerBase
    {
        private readonly MySQLContext _context;

        public AlbumController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumItem>>> GetAlbumItem()
        {
            return await _context.AlbumItems.ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumItem>> GetAlbumItem(long id)
        {
            var albumItem = await _context.AlbumItems.FindAsync(id);

            if (albumItem == null)
            {
                return NotFound();
            }

            return albumItem;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumItem(long id, AlbumItem albumItem)
        {
            if (id != albumItem.id)
            {
                return BadRequest();
            }

            _context.Entry(albumItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumItemExists(id))
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

        [HttpGet("{id}/morceaux")]
        public async Task<IActionResult> GetSongsByAlbumId(long id)
        {
            try
            {
                // Vérifier si l'ID de l'album existe
                var album = await _context.AlbumItems.FindAsync(id);

                if (album == null)
                {
                    return NotFound(new { message = $"Aucun album trouvé avec l'ID {id}. Impossible de récupérer les morceaux." });
                }

                // Récupérer les morceaux associés à l'album
                var morceaux = await _context.morceaux
                    .Where(m => m.AlbumId == id)
                    .ToListAsync();

                return Ok(new { data = morceaux });
            }
            catch (Exception ex)
            {
                // Gérer les erreurs et renvoyer un message approprié
                Console.Error.WriteLine(ex);
                return StatusCode(500, new { message = "Une erreur s'est produite lors de la récupération des morceaux.", error = ex.Message });
            }
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumItem>> PostAlbumItem(AlbumItem albumItem)
        {
            _context.AlbumItems.Add(albumItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbumItem", new { id = albumItem.id }, albumItem);
        }

        [HttpPost("{id}/morceaux")]
        public async Task<IActionResult> AddMorceauByAlbumId(long id, [FromBody] MorceauItem newMorceau)
        {
            try
            {
                // Vérifier si l'album avec l'ID spécifié existe
                var album = await _context.AlbumItems.FindAsync(id);
                if (album == null)
                {
                    return NotFound(new { message = $"Aucun album trouvé avec l'ID {id}. Impossible d'ajouter le morceau." });
                }

                // Si l'album existe, assigner l'albumId au morceau et l'ajouter à la base de données
                newMorceau.AlbumId = id;

                _context.morceaux.Add(newMorceau);
                await _context.SaveChangesAsync();

                return StatusCode(201, new { message = "Nouveau morceau ajouté avec succès" });
            }
            catch (Exception ex)
            {
                // Gérer les erreurs et renvoyer un message approprié
                Console.Error.WriteLine(ex);
                return StatusCode(500, new { message = "Une erreur s'est produite lors de l'ajout du morceau.", error = ex.Message });
            }
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumItem(long id)
        {
            var albumItem = await _context.AlbumItems.FindAsync(id);
            if (albumItem == null)
            {
                return NotFound();
            }

            _context.AlbumItems.Remove(albumItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumItemExists(long id)
        {
            return _context.AlbumItems.Any(e => e.id == id);
        }
    }
}
