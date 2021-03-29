using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicRecommendations.Models;

namespace MusicRecommendations.Data
{
    public class MusicRecommendationsContext : DbContext
    {
        public MusicRecommendationsContext (DbContextOptions<MusicRecommendationsContext> options)
            : base(options)
        {
        }

        public DbSet<MusicRecommendations.Models.MusicModel> MusicModel { get; set; }
    }
}
