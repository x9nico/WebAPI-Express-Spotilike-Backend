using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPI_Express_Spotilike.Models;


    namespace WebAPI_Express_Spotilike.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class RegisterController : ControllerBase
        {
            private readonly MySQLContext _context;

            public RegisterController(MySQLContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> Register([FromBody] UserItem newUser)
            {
                // Validation des données d'entrée
                if (newUser == null || string.IsNullOrEmpty(newUser.NomUtilisateur) || string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.Password))
                {
                    return BadRequest(new { message = "Toutes les informations sont requises." });
                }

            // Vérifier si un utilisateur avec le même nom d'utilisateur ou email existe déjà
            var existingUser = await _context.users
                .FirstOrDefaultAsync(u => u.NomUtilisateur == newUser.NomUtilisateur || u.Email == newUser.Email);

            if (existingUser != null)
                {
                    return Conflict(new { message = "Un utilisateur avec ce nom d'utilisateur ou cet email existe déjà." });
                }

                // Enregistrement du nouvel utilisateur
                _context.users.Add(newUser);
                await _context.SaveChangesAsync();

                return StatusCode(201, new { message = "Compte créé avec succès." });
            }
        }
    }