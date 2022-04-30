using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;

namespace WebApplication2.Services.MatchServices
{
    public interface IMatchService
    {
        int CreateMatch(CreateMatchDto dto);
        Match? Get(int id);
        IEnumerable<Match> GetAll();
        IEnumerable<Match>? GetMatchesByGameweek(int gameweek);
        bool ChangeResultOfMatch(int matchId, int result, int goalHome, int goalAway);
    }
}