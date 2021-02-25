using MusicRecommendations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendations.Services
{
    public class RecommendationServices
    {
        public IEnumerable<MusicModel> GetRecommendations()
        {
            return new MusicModel[] {
             new MusicModel
                { Id = 1, SongName = "Couldn't stand the weather", ArtistName = "Stevie Rayvon", AlbumName = "Texas Flood" }
            };
        }
    }
}
