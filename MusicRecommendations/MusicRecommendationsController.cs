using Microsoft.AspNetCore.Mvc;
using MusicRecommendations.Models;
using MusicRecommendations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicRecommendations
{
    [Route("api/recommendations")]
    [ApiController]
    public class MusicRecommendationsController : ControllerBase
    {
        private readonly MusicRecommendations.Data.MusicRecommendationsContext _context;

        public MusicRecommendationsController(MusicRecommendations.Data.MusicRecommendationsContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<MusicModel>> Get()
        {
            return await new RecommendationServices().GetRecommendations(_context, null, null);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<MusicModel> Get(int id)
        {
            return await new RecommendationServices().GetSingleRecommendation(_context, id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<MusicModel> Post([FromBody] string value)
        {
            return (MusicModel)await new RecommendationServices().CreateRecommendation(_context);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<MusicModel> Put(int id, [FromBody] string value)
        {
            return await new RecommendationServices().UpdateRecommendation(_context, id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<MusicModel> Delete(int id)
        {
            return await new RecommendationServices().DeleteRecommendation(_context, id);
        }
    }
}
