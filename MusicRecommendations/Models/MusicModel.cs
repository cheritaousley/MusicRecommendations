using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicRecommendations.Models
{
    public class MusicModel
    {
        public int Id { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        public string Genre { get; set; }
        public bool isRecommended { get; set; }
    }
}
