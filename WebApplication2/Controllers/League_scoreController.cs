using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/league_score")]
    public class League_scoreController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public League_scoreController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("user_score")]
        public ActionResult GetScoreByUserAndLeague(int user_id, int league_id)
        {
            var result = _dbContext
                .League_scores
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.UserId == user_id)
                .FirstOrDefault();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{user_id}")]
        public ActionResult GetScoreByUser([FromRoute]int user_id)
        {
            var result = _dbContext
                .League_scores
                .Where(v => v.UserId == user_id)
                .ToList();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{league_id}")]
        public ActionResult GetScoreByLeague([FromRoute]int league_id)
        {
            var result = _dbContext
                .League_scores
                .Where(v => v.LeagueId == league_id)
                .ToList();

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
