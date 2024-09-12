using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Express_Spotilike.Models
{
    public class UserItem
    {

        public long id { get; set; }
        
        [Column("nomUtilisateur")]
        public string NomUtilisateur { get; set; }

        
        [Column("email")]
        public string Email { get; set; }

        
        [Column("password")]
        public string Password { get; set; }
    }
}
