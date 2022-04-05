using WebApplication2.Entities;
using WebApplication2.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services.ClubServices
{
    public class ClubService : IClubService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClubService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<GetClubDto> GetAll()
        {
            var result = _dbContext
                .Clubs
                .Include(f => f.Footballers)
                .ToList();

            var resultDtos = _mapper.Map<List<GetClubDto>>(result);

            return resultDtos;
        }

        public GetClubDto? GetById(int id)
        {
            var result = _dbContext
                .Clubs
                .Include(f => f.Footballers)
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return null;

            var resultDto = _mapper.Map<GetClubDto>(result);

            return resultDto;
        }

        public GetClubDto? GetByClubName(string name)
        {
            var result = _dbContext
                .Clubs
                .Include(f => f.Footballers)
                .FirstOrDefault(u => u.Nameclub == name);

            if (result is null) return null;

            var resultDto = _mapper.Map<GetClubDto>(result);

            return resultDto;
        }

        public int CreateClub(CreateClubDto dto)
        {
            var club = _mapper.Map<Club>(dto);

            _dbContext.Clubs.Add(club);
            _dbContext.SaveChanges();

            return club.Id;
        }
    }
}
