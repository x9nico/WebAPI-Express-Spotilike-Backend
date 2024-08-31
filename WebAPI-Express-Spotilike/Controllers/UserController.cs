using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI_Express_Spotilike.Models;

namespace WebAPI_Express_Spotilike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("me")]
        [Authorize]
        public IActionResult current_user()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.NomUtilisateur}");
        }

        private UserItem GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserItem
                {
                    NomUtilisateur = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                };
            }
            return null;
        }
    }
}
