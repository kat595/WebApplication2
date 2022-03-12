using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.League_founderServices
{
    public interface ILeague_founderService
    {
        void CreateLeague_founder(CreateLeague_founderDto dto);
        IEnumerable<League_founder> GetAll();
        IEnumerable<League_founder> GetById(int id);
        League_founder? GetFounderByUserAndLeague(int user_id, int league_id);
    }
}