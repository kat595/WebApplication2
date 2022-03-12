using WebApplication2.Entities;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication2.Services.League_scoreServices
{
    public class League_scoreService : ILeague_scoreService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public League_scoreService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool UpdateUsersScoreByGameweek(int gameweek) // metoda do przetestowania, punkty do ewentualnej modyfikacji
        {
            var dbScores = _dbContext
                .League_scores
                .ToList();

            foreach(var x in dbScores)
            {
                var tips = _dbContext
                    .Tips
                    .Include(m => m.Match)
                    .Where(g => g.Match.Gameweek == gameweek)
                    .Where(u => u.UserId == x.UserId)
                    .Where(l => l.LeagueId == x.LeagueId)
                    .ToList();


                foreach(var y in tips)
                {
                    var match = _dbContext
                    .Matchs
                    .FirstOrDefault(m => m.Id == y.MatchId);

                    if (match is null) return false;

                    var odd = _dbContext
                        .Odds
                        .FirstOrDefault(m => m.MatchId == match.Id);

                    if(odd is null) return false;

                    var footballerStat = _dbContext
                        .Footballer_stats
                        .Where(f => f.FootballerId == y.FootballerId)
                        .Where(m => m.MatchId == match.Id)
                        .FirstOrDefault();

                    if (footballerStat is null) return false;

                    var footballer = _dbContext
                        .Footballers
                        .FirstOrDefault(f => f.Id == y.FootballerId);

                    if (footballer is null) return false;

                    //porownanie wyniku meczu z typem gracza
                    if(match.Result == 1 && y.Tip_score == 1)
                    {
                        x.Score += odd.Odd_home * 10;
                    }
                    else if(match.Result == 2 && y.Tip_score == 2)
                    {
                        x.Score += odd.Odd_away * 10;
                    }
                    else if(match.Result == 0 && y.Tip_score == 0)
                    {
                        x.Score += odd.Odd_draw * 10;
                    }

                    //porownanie liczby goli w meczu z typem gracza
                    if(((match.Goal_home + match.Goal_away) >= 3) && (y.Goal_count >= 3))
                    {
                        x.Score += odd.Odd_over2 * 5;
                    }
                    else if (((match.Goal_home + match.Goal_away) < 3) && (y.Goal_count < 3))
                    {
                        x.Score += odd.Odd_under2 * 5;
                    }

                    //porownanie czy dokładny wynik meczu pokrywa się z typem gracza
                    if(match.Goal_home == y.Tip_goal_home && match.Goal_away == y.Tip_goal_away)
                    {
                        x.Score += 50;
                    }

                    //porownanie wytypowanego wyroznionego zawodnika przez gracza z jego statystykami z meczu
                    if(footballer.Position == "Goalkeeper" && footballerStat.If_goal == 1)
                    {
                        x.Score += 200;
                    }
                    if (footballer.Position == "Goalkeeper" && footballerStat.If_cleansheet == 1)
                    {
                        x.Score += odd.Odd_cleansheet * 10;
                    }
                    if (footballer.Position == "Defender" && footballerStat.If_goal == 1)
                    {
                        x.Score += odd.Odd_goal_defender * 20;
                    }
                    else if(footballer.Position == "Midfielder" && footballerStat.If_goal == 1)
                    {
                        x.Score += odd.Odd_goal_midfielder * 10;
                    }
                    else if (footballer.Position == "Forward" && footballerStat.If_goal == 1)
                    {
                        x.Score += odd.Odd_goal_forward * 5;
                    }


                }
            }
            _dbContext.SaveChanges();
            return true;
        }

        public League_score? GetScoreByUserAndLeague(int user_id, int league_id)
        {
            var result = _dbContext
                .League_scores
                .Where(u => u.LeagueId == league_id)
                .Where(v => v.UserId == user_id)
                .FirstOrDefault();

            if (result == null) return null;

            return result;
        }

        public IEnumerable<League_score> GetScoreByUser(int user_id)
        {
            var result = _dbContext
                .League_scores
                .Where(v => v.UserId == user_id)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<League_score>();

            return result;
        }

        public IEnumerable<League_score> GetScoreByLeague(int league_id)
        {
            var result = _dbContext
                .League_scores
                .Where(v => v.LeagueId == league_id)
                .ToList();

            if (result.Count == 0) return Enumerable.Empty<League_score>();

            return result;
        }

        public void CreateLeague_score(CreateLeague_scoreDto dto)
        {
            var league_score = _mapper.Map<League_score>(dto);

            _dbContext.League_scores.Add(league_score);
            _dbContext.SaveChanges();
        }
    }
}
