using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.ClubServices
{
    public interface IClubService
    {
        int CreateClub(CreateClubDto dto);
        IEnumerable<GetClubDto> GetAll();
        GetClubDto? GetByClubName(string name);
        GetClubDto? GetById(int id);
    }
}