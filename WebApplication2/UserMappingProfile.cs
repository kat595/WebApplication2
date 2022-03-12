using AutoMapper;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Models.GetDtos;
using WebApplication2.Controllers;

namespace WebApplication2
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<Footballer, GetFootballerDto>();
            CreateMap<Footballer, GetFootballerWithClubDto>()
            .ForMember(m => m.Club, c => c.MapFrom(s => s.Club.Nameclub));
            CreateMap<League, GetLeagueDto>();
            CreateMap<Club, GetClubDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<CreateFootballerDto, Footballer>();
            CreateMap<CreateFootballer_statDto, Footballer_stat>();
            CreateMap<CreateLeague_founderDto, League_founder>();
            CreateMap<CreateLeague_scoreDto, League_score>();
            CreateMap<CreateLeagueDto, League>();
            CreateMap<CreateMatchDto, Match>();
            CreateMap<CreateOddDto, Odd>();
            CreateMap<CreateTipDto, Tip>();
        }
    }
}
