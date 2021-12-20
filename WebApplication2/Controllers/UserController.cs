using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public UserController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _dbContext
                .Users
                .ToList();

            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute]int id)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);
            
            if (user is null) return NotFound();

            return Ok(user);

        }

    }
}
