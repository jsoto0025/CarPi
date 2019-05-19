using AutoMapper;
using DataAccess.Database;
using CarPi.DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPi.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Position, PositionDTO>();
            CreateMap<Route, RouteDTO>()
                .ForMember(x => x.Position, mapping => mapping.MapFrom(src => src.Position));
        }
    }
}
