using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.OddServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/odd")]
    public class OddController : ControllerBase
    {
        private readonly IOddService _oddService;

        public OddController(IOddService oddService)
        {
            _oddService = oddService;
        }

        [HttpGet("{match_id}")]
        public ActionResult GetByMatchId([FromRoute]int match_id)
        {
            var result = _oddService.GetByMatchId(match_id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateOdd([FromBody] CreateOddDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _oddService.CreateOdd(dto);

            return Created($"/api/odd/{result}", null);
        }

    }
}
