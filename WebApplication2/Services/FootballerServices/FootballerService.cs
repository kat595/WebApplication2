using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication2.Services.FootballerServices
{
    public class FootballerService : IFootballerService
    {
        private readonly TiproomDbContext _dbContext;
        private readonly IMapper _mapper;

        public FootballerService(TiproomDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<GetFootballerWithClubDto> GetAll()
        {
            var result = _dbContext
                .Footballers
                .Include(c => c.Club)
                .ToList();

            var resultDto = _mapper.Map<List<GetFootballerWithClubDto>>(result);

            return resultDto;
        }

        public GetFootballerWithClubDto? GetById(int id)
        {
            var result = _dbContext
                .Footballers
                .FirstOrDefault(u => u.Id == id);

            if (result is null) return null;

            var resultDto = _mapper.Map<GetFootballerWithClubDto>(result);

            return resultDto;
        }

        public int CreateFootballer(CreateFootballerDto dto)
        {
            var footballer = _mapper.Map<Footballer>(dto);

            _dbContext.Footballers.Add(footballer);
            _dbContext.SaveChanges();

            return footballer.Id;
        }
    }
}
