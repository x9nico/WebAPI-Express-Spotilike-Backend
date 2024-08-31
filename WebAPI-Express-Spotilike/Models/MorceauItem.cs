using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Express_Spotilike.Models
{
    public class MorceauItem
    {
        public long id { get; set; }

        public string titre { get; set; }

        public TimeSpan durée { get; set; }

        [Column("artiste_id")]
        public long ArtisteId { get; set; }

        [ForeignKey("ArtisteId")]
        public ArtisteItem Artiste { get; set; }

        [Column("genre_id")]
        public long GenreId { get; set; }

        [ForeignKey("GenreId")]
        public GenreItem Genre { get; set; }

        [Column("album_id")]
        public long AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public AlbumItem Album { get; set; }
    }
}
