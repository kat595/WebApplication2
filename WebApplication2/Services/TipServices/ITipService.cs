using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.TipServices
{
    public interface ITipService
    {
        int CreateTip(CreateTipDto dto);
        Tip? GetTipById(int id);
        Tip? GetUserTipByLeagueAndMatch(int user_id, int match_id, int league_id);
        bool Delete(int id);
    }
}