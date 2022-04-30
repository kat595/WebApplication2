using WebApplication2.Entities;
using WebApplication2.Models.GetDtos;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.MatchServices
{
    public class MatchService : IMatchService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public MatchService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public IEnumerable<Match> GetAll()
        {
            var result = _dbContext
                .Matchs
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<Match>();

            return result;
        }


        public Match? Get(int id)
        {
            var result = _dbContext
                .Matchs
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return null;

            return result;

        }


        public IEnumerable<Match> GetMatchesByGameweek(int gameweek)
        {
            var result = _dbContext
                .Matchs
                .Where(u => u.Gameweek == gameweek)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<Match>();

            return result;

        }

        public int CreateMatch(CreateMatchDto dto)
        {

            var match = _mapper.Map<Match>(dto);

            _dbContext.Matchs.Add(match);
            _dbContext.SaveChanges();

            return match.Id;
        }

        public bool ChangeResultOfMatch(int matchId, int result, int goalHome, int goalAway)
        {
            var match = _dbContext
                .Matchs
                .FirstOrDefault(i => i.Id == matchId);

            if (match is null) return false;

            match.Result = result;
            match.Goal_home = goalHome;
            match.Goal_away = goalAway;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
