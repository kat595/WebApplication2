using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.League_scoreServices
{
    public interface ILeague_scoreService
    {
        void CreateLeague_score(CreateLeague_scoreDto dto);
        IEnumerable<League_score>? GetScoreByLeague(int league_id);
        IEnumerable<League_score>? GetScoreByUser(int user_id);
        League_score? GetScoreByUserAndLeague(int user_id, int league_id);
        bool UpdateUsersScoreByGameweek(int gameweek);
    }
}