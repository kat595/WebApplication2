using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/odd")]
    public class OddController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public OddController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{match_id}")]
        public ActionResult GetByMatchId([FromRoute]int match_id)
        {
            var result = _dbContext
                .Odds
                .Where(u => u.MatchId == match_id)
                .FirstOrDefault();

            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}
