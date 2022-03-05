using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/footballer_stat")]
    public class Footballer_statController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public Footballer_statController(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Footballer_stat>> GetAll()
        {
            var result = _dbContext
                .Footballer_stats
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var result = _dbContext
                .Footballer_stats
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return NotFound();

            return Ok(result);
        }
        

        [HttpGet("{footballer_id}")]
        public ActionResult<IEnumerable<Footballer_stat>> GetByFootballerId([FromRoute]int footballer_id)
        {
            var result = _dbContext
                .Footballer_stats
                .Where(u => u.FootballerId == footballer_id)
                .ToList();

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{match_id}")]
        public ActionResult<IEnumerable<Footballer_stat>> GetByMatchId([FromRoute]int match_id)
        {
            var result = _dbContext
                .Footballer_stats
                .Where(u => u.MatchId == match_id)
                .ToList();

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateFootballer_stat([FromBody] CreateFootballer_statDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var footballer_stat = _mapper.Map<Footballer_stat>(dto);

            _dbContext.Footballer_stats.Add(footballer_stat);
            _dbContext.SaveChanges();

            return Created($"/api/footballer_stat/{footballer_stat.Id}", null);
        }
    }
}
