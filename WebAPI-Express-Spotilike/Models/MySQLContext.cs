using Microsoft.EntityFrameworkCore;
using WebAPI_Express_Spotilike.Models;


namespace WebAPI_Express_Spotilike.Models
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        public DbSet<WebAPI_Express_Spotilike.Models.ArtisteItem> ArtisteItems { get; set; }
        public DbSet<WebAPI_Express_Spotilike.Models.AlbumItem> AlbumItems { get; set; }
        public DbSet<WebAPI_Express_Spotilike.Models.GenreItem> GenreItems { get; set; }

        public DbSet<WebAPI_Express_Spotilike.Models.MorceauItem> morceaux { get; set; }

        public DbSet<WebAPI_Express_Spotilike.Models.UserItem> users { get; set; }

    }
}

