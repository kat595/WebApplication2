using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/tip")]
    public class TipController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public TipController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetTipById([FromRoute]int id)
        {
            var result = _dbContext
                .Tips
                .FirstOrDefault(t => t.Id == id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("user_league_matchTip")]
        public ActionResult GetUserTipByLeagueAndMatch(int user_id, int match_id, int league_id)
        {
            var result = _dbContext
                .Tips
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.UserId == user_id)
                .Where(r => r.MatchId == match_id)
                .FirstOrDefault();

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
