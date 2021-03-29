using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicRecommendations.Models
{
    public class MusicModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        public bool isRecommended { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
