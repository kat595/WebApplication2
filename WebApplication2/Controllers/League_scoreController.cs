using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.ModifyDtos;
using WebApplication2.Services.League_scoreServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/league_score")]
    public class League_scoreController : ControllerBase
    {
        private readonly ILeague_scoreService _league_scoreService;

        public League_scoreController(ILeague_scoreService league_ScoreService)
        {
            _league_scoreService = league_ScoreService;
        }

        [HttpGet("user_score")]
        public ActionResult<League_score> GetScoreByUserAndLeague(int user_id, int league_id)
        {
            var result = _league_scoreService.GetScoreByUserAndLeague(user_id, league_id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("{user_id}")]
        public ActionResult<IEnumerable<League_score>> GetScoreByUser([FromRoute]int user_id)
        {
            var result = _league_scoreService.GetScoreByUser(user_id);

            return Ok(result);
        }

        [HttpGet("league_id")]
        public ActionResult<IEnumerable<League_score>> GetScoreByLeague(int league_id)
        {
            var result = _league_scoreService.GetScoreByLeague(league_id);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateLeague_score([FromBody] CreateLeague_scoreDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _league_scoreService.CreateLeague_score(dto);

            return Ok();
        }
        [HttpPut("update-scores-after-gameweek")]
        public ActionResult UpdateScoresByGameweek([FromBody] UpdateScoresByGameweekDto dto)
        {
            var ifUpdated = _league_scoreService.UpdateUsersScoreByGameweek(dto.Gameweek);

            if(ifUpdated == false) return BadRequest(ModelState);

            return Ok();
        }
    }
}
