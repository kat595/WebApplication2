using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.Footballer_statServices
{
    public interface IFootballer_statService
    {
        int CreateFootballer_stat(CreateFootballer_statDto dto);
        IEnumerable<Footballer_stat> GetAll();
        IEnumerable<Footballer_stat> GetByFootballerId(int footballer_id);
        Footballer_stat? GetById(int id);
        IEnumerable<Footballer_stat> GetByMatchId(int match_id);
    }
}