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

        public async Task<IList<MusicModel>> CreateRecommendation(Data.MusicRecommendationsContext context, MusicModel newRecommendation)
        {
            // want to check if it already exists by song name
            
            bool recommendationExists = context.MusicModel.Any(x => x.SongName == newRecommendation.SongName);
         
            if (!recommendationExists)
            {
                context.Add(newRecommendation);
                await context.SaveChangesAsync();
            }
            return await context.MusicModel.ToListAsync();
        }

        public async Task<MusicModel> UpdateRecommendation(Data.MusicRecommendationsContext context, int id, MusicModel updatedRecommendation)
        {
            var songQuery = from s in context.MusicModel
                       where s.Id == id
                       select s;
            var song = await songQuery.SingleAsync();
            // look at each field from this id and update any field that is being edited by user
            song.SongName = updatedRecommendation.SongName;
            song.AlbumName = updatedRecommendation.AlbumName;
            song.ArtistName = updatedRecommendation.ArtistName;
            song.Genre = updatedRecommendation.Genre;
            song.Price = updatedRecommendation.Price;
            song.isRecommended = updatedRecommendation.isRecommended;

            await context.SaveChangesAsync();
            return song;
        }

        public async Task<IList<MusicModel>> DeleteRecommendation(Data.MusicRecommendationsContext context, int id)
        {
            var song = from s in context.MusicModel
                       where s.Id == id
                       select s;
            context.Remove(id);
            // context.SaveChanges();
            await context.SaveChangesAsync();
            // return new list without the deleted song
            return await context.MusicModel.ToListAsync();
        }
    }
}
