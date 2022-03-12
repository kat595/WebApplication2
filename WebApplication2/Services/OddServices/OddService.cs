using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;

namespace WebApplication2.Services.OddServices
{
    public class OddService : IOddService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public OddService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public Odd? GetByMatchId(int match_id)
        {
            var result = _dbContext
                .Odds
                .Where(u => u.MatchId == match_id)
                .FirstOrDefault();

            if (result == null) return null;

            return result;
        }


        public int CreateOdd(CreateOddDto dto)
        {
            var odd = _mapper.Map<Odd>(dto);

            _dbContext.Odds.Add(odd);
            _dbContext.SaveChanges();

            return odd.Id;
        }
    }
}
