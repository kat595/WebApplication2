using AutoMapper;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<CreateFootballerDto, Footballer>();
            CreateMap<CreateFootballer_statDto, Footballer_stat>();
        }
    }
}
