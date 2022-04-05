using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.TipServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/tip")]
    [ApiController]
    public class TipController : ControllerBase
    {
        private readonly ITipService _tipService;

        public TipController(ITipService tipService)
        {
            _tipService = tipService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _tipService.Delete(id);

            if (isDeleted == true) return NoContent();

            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetTipById([FromRoute]int id)
        {
            var result = _tipService.GetTipById(id);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("user_league_matchTip")]
        public ActionResult GetUserTipByLeagueAndMatch(int user_id, int match_id, int league_id)
        {
            var result = _tipService.GetUserTipByLeagueAndMatch(user_id, match_id, league_id);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateTip([FromBody] CreateTipDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _tipService.CreateTip(dto);

            return Created($"/api/tip/{result}", null);
        }
    }
}
