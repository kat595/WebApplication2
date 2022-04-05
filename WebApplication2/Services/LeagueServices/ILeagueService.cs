using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.LeagueServices
{
    public interface ILeagueService
    {
        int CreateLeague(CreateLeagueDto dto);
        IEnumerable<GetLeagueDto>? GetAll();
        GetLeagueDto? GetById(int id);
        GetLeagueDto? GetByLeagueName(string name);
        bool AddNewUsertoLeague(int userId, int leagueId);
        IEnumerable<GetLeagueDto> GetUserLeagues(int userId);
    }
}