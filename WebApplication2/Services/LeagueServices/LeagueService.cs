using WebApplication2.Entities;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication2.Services.LeagueServices
{
    public class LeagueService : ILeagueService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeagueService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool AddNewUsertoLeague(int userId, int leagueId)
        {
            var league = _dbContext
                .Leagues
                .FirstOrDefault(l => l.Id == leagueId);

            if (league == null) return false;

            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == userId);

            if (user == null) return false;
            if(league.Users is null)
            {
                league.Users = new List<User>();
            }
            
            league.Users.Add(user);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<GetLeagueDto> GetAll()
        {
            var leagues = _dbContext
                .Leagues
                .Include(u => u.Users)
                .ToList();

            if (leagues.Count == 0) return Enumerable.Empty<GetLeagueDto>();

            var leaguesDto = _mapper.Map<List<GetLeagueDto>>(leagues);


            return leaguesDto;
        }

        public IEnumerable<GetLeagueDto> GetUserLeagues(int userId)
        {
            var userLeagues = _dbContext
                .League_scores
                .Where(x => x.UserId == userId)
                .ToList();

            var leagues = new List<GetLeagueDto>();

            foreach(var x in userLeagues)
            {
                var league = _dbContext
                    .Leagues
                    .FirstOrDefault(l => l.Id == x.LeagueId);

                var leagueDto = _mapper.Map<GetLeagueDto>(league);

                leagues.Add(leagueDto);
            }
            
            if (leagues.Count == 0) return Enumerable.Empty<GetLeagueDto>();

            return leagues;
        }


        public GetLeagueDto? GetById(int id)
        {
            var league = _dbContext
                .Leagues
                .Include(u => u.Users)
                .FirstOrDefault(u => u.Id == id);

            if (league is null) return null;

            var leaguesDto = _mapper.Map<GetLeagueDto>(league);

            return leaguesDto;
        }

        public GetLeagueDto? GetByLeagueName(string name)
        {
            var league = _dbContext
                .Leagues
                .Include(u => u.Users)
                .FirstOrDefault(u => u.League_name == name);

            if (league is null) return null;

            var leagueDto = _mapper.Map<GetLeagueDto>(league);

            return leagueDto;

        }

        public int CreateLeague(CreateLeagueDto dto)
        {

            var league = _mapper.Map<League>(dto);

            _dbContext.Leagues.Add(league);
            _dbContext.SaveChanges();

            return league.Id;
        }
    }
}
