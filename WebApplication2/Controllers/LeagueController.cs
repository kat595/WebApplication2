using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;
using WebApplication2.Models.ModifyDtos;
using WebApplication2.Services.LeagueServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/league")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpPut("add-user-to-league")]
        public ActionResult AddNewUserToLeague([FromBody]AddUserToLeagueDto dto)
        {
            var isUpdated = _leagueService.AddNewUsertoLeague(dto.userId, dto.leagueId);

            if(isUpdated == false) return NotFound();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetLeagueDto>> GetAll()
        {
            var leagues = _leagueService.GetAll();

            return Ok(leagues);
        }

        [HttpGet("user-leagues")]
        public ActionResult<IEnumerable<GetLeagueDto>> GetUserLeagues([FromBody] GetUserLeaguesDto dto)
        {
            var leagues = _leagueService.GetUserLeagues(dto.UserId);

            return Ok(leagues);
        }

        [HttpGet("{id}")]
        public ActionResult<GetLeagueDto> GetById([FromRoute]int id)
        {
            var league = _leagueService.GetById(id);

            if (league is null) return NotFound();

            return Ok(league);
        }

        [HttpGet("name")]
        public ActionResult<GetLeagueDto> GetByLeagueName([FromBody] GetLeagueByLeagueNameDto dto)
        {
            var league = _leagueService.GetByLeagueName(dto.name);

            if (league is null) return NotFound();

            return Ok(league);

        }

        [HttpPost]
        public ActionResult CreateLeague([FromBody] CreateLeagueDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _leagueService.CreateLeague(dto);

            return Created($"/api/league/{result}", null);
        }

    }
}
