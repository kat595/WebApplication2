using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.Footballer_statServices
{
    public class Footballer_statService : IFootballer_statService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public Footballer_statService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Footballer_stat> GetAll()
        {
            var result = _dbContext
                .Footballer_stats
                .ToList();

            return result;
        }

        public Footballer_stat? GetById(int id)
        {
            var result = _dbContext
                .Footballer_stats
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return null;

            return result;
        }


        public IEnumerable<Footballer_stat> GetByFootballerId(int footballer_id)
        {
            var result = _dbContext
                .Footballer_stats
                .Where(u => u.FootballerId == footballer_id)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<Footballer_stat>();

            return result;
        }

        public IEnumerable<Footballer_stat> GetByMatchId(int match_id)
        {
            var result = _dbContext
                .Footballer_stats
                .Where(u => u.MatchId == match_id)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<Footballer_stat>();

            return result;
        }

        public int CreateFootballer_stat(CreateFootballer_statDto dto)
        {

            var footballer_stat = _mapper.Map<Footballer_stat>(dto);

            _dbContext.Footballer_stats.Add(footballer_stat);
            _dbContext.SaveChanges();

            return footballer_stat.Id;
        }
    }
}
