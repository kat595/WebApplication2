using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/footballer")]
    public class FootballerController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public FootballerController(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Footballer>> GetAll()
        {
            var result = _dbContext
                .Footballers
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _dbContext
                .Footballers
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateClub([FromBody] CreateFootballerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var footballer = _mapper.Map<Footballer>(dto);

            _dbContext.Footballers.Add(footballer);
            _dbContext.SaveChanges();

            return Created($"/api/footballer/{footballer.Id}", null);
        }
    }
}
