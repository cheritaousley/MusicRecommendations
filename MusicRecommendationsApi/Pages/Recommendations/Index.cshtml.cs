using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicRecommendations.Data;
using MusicRecommendations.Models;
using MusicRecommendations.Services;

namespace MusicRecommendations.Pages.Recommendations
{
    public class IndexModel : PageModel
    {
        private readonly MusicRecommendations.Data.MusicRecommendationsContext _context;

        public IndexModel(MusicRecommendations.Data.MusicRecommendationsContext context)
        {
            _context = context;
        }

        public IList<MusicModel> MusicModel { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }

        public string ArtistName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MusicGenre { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of artists.
            //IQueryable<string> artistQuery = from m in _context.MusicModel
            //                                orderby m.ArtistName
            //                                select m.ArtistName;

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.MusicModel
                                            orderby m.Genre
                                            select m.Genre;
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            MusicModel = await new RecommendationServices().GetRecommendations(_context, SearchString, MusicGenre);
        }

    }
}
