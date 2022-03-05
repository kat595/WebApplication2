using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/match")]
    public class MatchController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public MatchController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Match>> GetAll()
        {
            var result = _dbContext
                .Matchs
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] int id)
        {
            var result = _dbContext
                .Matchs
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return NotFound();

            return Ok(result);

        }

        [HttpGet("{gameweek}")]
        public ActionResult<User> GetMatchesByGameweek([FromRoute] int gameweek)
        {
            var result = _dbContext
                .Matchs
                .Where(u => u.Gameweek == gameweek)
                .ToList();

            if (result is null) return NotFound();

            return Ok(result);

        }
    }
}
