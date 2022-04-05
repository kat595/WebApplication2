using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.ClubServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetClubDto>> GetAll()
        {
            var result = _clubService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var result = _clubService.GetById(id);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpGet("name")]
        public ActionResult GetByClubName(string name)
        {
            var result = _clubService.GetByClubName(name);

            if (result is null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult CreateClub([FromBody]CreateClubDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _clubService.CreateClub(dto);

            return Created($"/api/club/{result}", null);
        }
    }
}
