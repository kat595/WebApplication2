using WebApplication2.Models;

namespace WebApplication2.Services.UserServices
{
    public interface IUserService
    {
        int CreateUser(CreateUserDto dto);
        IEnumerable<GetUserDto> GetAll();
        GetUserDto? GetById(int id);
        bool Delete(int id);
        int? GetUserIdByPasswordAndNickname(string nick, string password);
    }
}