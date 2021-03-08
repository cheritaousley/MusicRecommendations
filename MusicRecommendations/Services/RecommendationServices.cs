using Microsoft.EntityFrameworkCore;
using MusicRecommendations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommendations.Services
{
    public class RecommendationServices
    {
        public async Task<IList<MusicModel>> GetRecommendations(Data.MusicRecommendationsContext context, string searchString, string musicGenre)
        {
            var musicRecs = from m in context.MusicModel
                            select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                musicRecs = musicRecs.Where(s => s.SongName.Contains(searchString));
            }
            //if (!string.IsNullOrEmpty(ArtistName))
            //{
            //    musicRecs = musicRecs.Where(x => x.ArtistName == ArtistName);
            //}
            if (!string.IsNullOrEmpty(musicGenre))
            {
                musicRecs = musicRecs.Where(x => x.Genre == musicGenre);
            }
            //Artists = new SelectList(await artistQuery.Distinct().ToListAsync());

            return await musicRecs.ToListAsync();
        }

        public async Task<MusicModel> GetSingleRecommendation(Data.MusicRecommendationsContext context, int id)
        {
            var song = from s in context.MusicModel
                       where s.Id == id
                       select s;
            return await song.SingleAsync();

        }

        public async Task<IList<MusicModel>> CreateRecommendation(Data.MusicRecommendationsContext context)
        {
            // want to check if it already exists by song name
            var musicRecs = from m in context.MusicModel
                            select m;
            var hs = new HashSet<string>();
            bool recommendationIsUnique = musicRecs.All(x => hs.Add(x.SongName));
           // bool isUnique = musicRecs.Distinct().Count() == musicRecs.Count();
            if (recommendationIsUnique)
            {
                context.Add(hs);
                // context.SaveChanges();
             await context.SaveChangesAsync();// why can't I return this
            }
            return await musicRecs.ToListAsync();
        }

        public async Task<MusicModel> UpdateRecommendation(Data.MusicRecommendationsContext context, int id)
        {
            var song = from s in context.MusicModel
                       where s.Id == id
                       select s;
            context.Update(id);
            await context.SaveChangesAsync();
            return await song.SingleAsync();
        }

        public async Task<MusicModel> DeleteRecommendation(Data.MusicRecommendationsContext context, int id)
        {
            var song = from s in context.MusicModel
                       where s.Id == id
                       select s;
            context.Remove(id);
            // context.SaveChanges();
            await context.SaveChangesAsync();
            return await song.SingleAsync();
        }
    }
}
