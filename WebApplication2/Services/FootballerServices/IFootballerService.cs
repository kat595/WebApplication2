using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;

namespace WebApplication2.Services.FootballerServices
{
    public interface IFootballerService
    {
        int CreateFootballer(CreateFootballerDto dto);
        IEnumerable<GetFootballerWithClubDto> GetAll();
        GetFootballerWithClubDto? GetById(int id);
    }
}