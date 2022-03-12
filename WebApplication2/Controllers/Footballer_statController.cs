using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.Footballer_statServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/footballer_stat")]
    public class Footballer_statController : ControllerBase
    {
        private readonly IFootballer_statService _footballer_StatService;

        public Footballer_statController(IFootballer_statService footballer_StatService)
        {
            _footballer_StatService = footballer_StatService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Footballer_stat>> GetAll()
        {
            var result = _footballer_StatService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Footballer_stat> GetById([FromRoute]int id)
        {
            var result = _footballer_StatService.GetById(id);

            if (result is null) return NotFound();

            return Ok(result);
        }
        

        [HttpGet("footballer_id")]
        public ActionResult<IEnumerable<Footballer_stat>> GetByFootballerId([FromRoute]int footballer_id)
        {
            var result = _footballer_StatService.GetByFootballerId(footballer_id);

            return Ok(result);
        }

        [HttpGet("match_id")]
        public ActionResult<IEnumerable<Footballer_stat>> GetByMatchId([FromRoute]int match_id)
        {
            var result = _footballer_StatService.GetByMatchId(match_id);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateFootballer_stat([FromBody] CreateFootballer_statDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _footballer_StatService.CreateFootballer_stat(dto);

            return Created($"/api/footballer_stat/{result}", null);
        }
    }
}
