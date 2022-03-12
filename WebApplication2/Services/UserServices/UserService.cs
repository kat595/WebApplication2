using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user == null) return false;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<GetUserDto> GetAll()
        {
            var users = _dbContext
                .Users
                .ToList();

            var userDtos = _mapper.Map<List<GetUserDto>>(users);

            return userDtos;
        }

        public GetUserDto? GetById(int id)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user is null) return null;

            var userDto = _mapper.Map<GetUserDto>(user);

            return userDto;
        }


        public int CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public int? GetUserIdByPasswordAndNickname(string nick, string password)
        {
            var user = _dbContext
                .Users
                .Where(n => n.Nick == nick)
                .Where(p => p.Password == password)
                .FirstOrDefault();

            if (user is null) return null;

            return user.Id;
        }
    }
}
