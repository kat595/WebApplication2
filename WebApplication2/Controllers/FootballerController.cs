using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;
using WebApplication2.Services.FootballerServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/footballer")]
    public class FootballerController : ControllerBase
    {
        private readonly IFootballerService _footballerService;

        public FootballerController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetFootballerWithClubDto>> GetAll()
        {
            var result = _footballerService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<GetFootballerWithClubDto> GetById([FromRoute] int id)
        {
            var result = _footballerService.GetById(id);

            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateClub([FromBody] CreateFootballerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _footballerService.CreateFootballer(dto);

            return Created($"/api/footballer/{result}", null);
        }
    }
}
