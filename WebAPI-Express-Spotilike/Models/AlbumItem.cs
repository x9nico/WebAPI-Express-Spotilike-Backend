using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Express_Spotilike.Models
{
    public class AlbumItem
    {
        public long id { get; set; }
        public string titre { get; set; }

        public string pochette { get; set; }

        public DateTime date_de_sortie { get; set; }

        [Column("artiste_id")]
        public long ArtisteId { get; set; }

        [ForeignKey("ArtisteId")]
        public ArtisteItem Artiste { get; set; }
    }
}
