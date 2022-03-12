using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.TipServices
{
    public class TipService : ITipService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public TipService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var tip = _dbContext
                .Tips
                .FirstOrDefault(u => u.Id == id);

            if (tip == null) return false;

            _dbContext.Tips.Remove(tip);
            _dbContext.SaveChanges();

            return true;
        }


        public Tip? GetTipById(int id)
        {
            var result = _dbContext
                .Tips
                .FirstOrDefault(t => t.Id == id);

            if (result == null) return null;

            return result;
        }


        public Tip? GetUserTipByLeagueAndMatch(int user_id, int match_id, int league_id)
        {
            var result = _dbContext
                .Tips
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.UserId == user_id)
                .Where(r => r.MatchId == match_id)
                .FirstOrDefault();

            if (result == null) return null;

            return result;
        }

        public int CreateTip(CreateTipDto dto)
        {
            var tip = _mapper.Map<Tip>(dto);

            _dbContext.Tips.Add(tip);
            _dbContext.SaveChanges();

            return tip.Id;
        }
    }
}
