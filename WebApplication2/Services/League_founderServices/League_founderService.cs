using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.League_founderServices
{
    public class League_founderService : ILeague_founderService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public League_founderService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<League_founder> GetAll()
        {
            var result = _dbContext
                .League_founders
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<League_founder>();

            return result;
        }

        public League_founder? GetFounderByUserAndLeague(int user_id, int league_id)
        {
            var result = _dbContext
                .League_founders
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.FounderId == user_id)
                .FirstOrDefault();

            if (result == null) return null;

            return result;
        }

        public IEnumerable<League_founder> GetById(int id)
        {
            var result = _dbContext
                .League_founders
                .Where(u => u.FounderId == id)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<League_founder>();

            return result;
        }

        public void CreateLeague_founder(CreateLeague_founderDto dto)
        {
            var league_founder = _mapper.Map<League_founder>(dto);

            _dbContext.League_founders.Add(league_founder);
            _dbContext.SaveChanges();
        }
    }
}
