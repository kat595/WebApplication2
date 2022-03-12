using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.League_founderServices;

namespace WebApplication2.Controllers
{
    [Route("api/league_founder")]
    public class League_founderController : ControllerBase 
    {
        private readonly ILeague_founderService _league_founderService;

        public League_founderController(ILeague_founderService league_FounderService)
        {
            _league_founderService = league_FounderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<League_founder>> GetAll()
        {
            var result = _league_founderService.GetAll();

            return Ok(result);
        }

        [HttpGet("league_founder")]
        public ActionResult<League_founder> GetScoreByUserAndLeague(int user_id, int league_id)
        {
            var result = _league_founderService.GetFounderByUserAndLeague(user_id, league_id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{founder_id}")]
        public ActionResult<IEnumerable<League_founder>> GetById([FromRoute] int id)
        {
            var result = _league_founderService.GetById(id);


            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateLeague_founder([FromBody] CreateLeague_founderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _league_founderService.CreateLeague_founder(dto);

            return Ok();
        }
    }
}
