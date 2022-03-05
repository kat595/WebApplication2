using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _dbContext
                .Users
                .ToList();

            var userDto = _mapper.Map<List<UserDto>>(users);

            return Ok(userDto);
        }
        
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get([FromRoute]int id)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user is null) return NotFound();

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = _mapper.Map<User>(dto);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Created($"/api/user/{user.Id}", null);
        }

    }
}
