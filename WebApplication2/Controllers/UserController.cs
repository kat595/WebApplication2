﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;
using WebApplication2.Services.UserServices;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id);

            if (isDeleted == true) return NoContent();

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetUserDto>> GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public ActionResult<GetUserDto> Get([FromRoute]int id)
        {
            var result = _userService.GetById(id);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("check-user")]
        public ActionResult<int> GetUserId([FromBody] GetUserIdByNickAndPassword dto)
        {
            var result = _userService.GetUserIdByPasswordAndNickname(dto.nick, dto.password);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var result = _userService.CreateUser(dto);

            return Created($"/api/user/{result}", null);
        }

    }
}
