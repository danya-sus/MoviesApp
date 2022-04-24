using AutoMapper;
using MoviesApp.Models;
using System;

namespace MoviesApp.Services_.Dto.AutoMapperProfile
{
    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}