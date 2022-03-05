using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/club")]
    public class ClubController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClubController(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<League>> GetAll()
        {
            var result = _dbContext
                .Clubs
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var result = _dbContext
                .Clubs
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{name}")]
        public ActionResult GetByClubName([FromRoute]string name)
        {
            var result = _dbContext
                .Clubs
                .FirstOrDefault(u => u.Nameclub == name);

            if (result is null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult CreateClub([FromBody]CreateClubDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var club = _mapper.Map<Club>(dto);

            _dbContext.Clubs.Add(club);
            _dbContext.SaveChanges();

            return Created($"/api/club/{club.Id}", null);
        }
    }
}
