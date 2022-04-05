using Microsoft.AspNetCore.Identity;
using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(TiproomDbContext dbContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
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
            _logger.LogWarning($"User with id: {id} GET Action invoked");

            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user is null) return null;

            var userDto = _mapper.Map<GetUserDto>(user);

            return userDto;
        }


        public int CreateUser(CreateUserDto dto)
        {
            var existNickname = _dbContext.Users
                .FirstOrDefault(n => n.Nick == dto.Nick);

            if(existNickname is not null)
            {
                return -1;
            }

            var user = _mapper.Map<User>(dto);
            var hashedPasswd = _passwordHasher.HashPassword(user, dto.Password);
            user.Password = hashedPasswd;

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
