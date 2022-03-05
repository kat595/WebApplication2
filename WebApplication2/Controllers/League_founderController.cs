using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/league_founder")]
    public class League_founderController : ControllerBase 
    {
        private readonly TiproomDbContext _dbContext;

        public League_founderController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<League_founder>> GetAll()
        {
            var result = _dbContext
                .League_founders
                .ToList();

            return Ok(result);
        }

        [HttpGet("league_founder")]
        public ActionResult GetScoreByUserAndLeague(int user_id, int league_id)
        {
            var result = _dbContext
                .League_founders
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.FounderId == user_id)
                .FirstOrDefault();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{founder_id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _dbContext
                .League_founders
                .Where(u => u.FounderId == id)
                .ToList();

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
