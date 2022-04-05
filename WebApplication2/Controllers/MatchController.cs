using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.ModifyDtos;
using WebApplication2.Services.MatchServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Match>> GetAll()
        {
            var result = _matchService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Match> Get([FromRoute] int id)
        {
            var result = _matchService.Get(id);

            if (result is null) return NotFound();

            return Ok(result);

        }

        [HttpGet("gameweek")]
        public ActionResult<IEnumerable<User>> GetMatchesByGameweek(int gameweek)
        {
            var result = _matchService.GetMatchesByGameweek(gameweek);

            return Ok(result);

        }

        [HttpPost]
        public ActionResult CreateMatch([FromBody] CreateMatchDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _matchService.CreateMatch(dto);

            return Created($"/api/match/{result}", null);
        }

        [HttpPut("change-match-result")]
        public ActionResult AddNewUserToLeague([FromBody] ChangeResultInMatchDto dto)
        {
            var isUpdated = _matchService.ChangeResultOfMatch(dto.MatchId, dto.Result, dto.Goal_home, dto.Goal_away);

            if (isUpdated == false) return NotFound();

            return Ok();
        }
    }
}
