using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.ClubServices
{
    public interface IClubService
    {
        int CreateClub(CreateClubDto dto);
        IEnumerable<GetClubDto> GetAll();
        Club? GetByClubName(string name);
        Club? GetById(int id);
    }
}