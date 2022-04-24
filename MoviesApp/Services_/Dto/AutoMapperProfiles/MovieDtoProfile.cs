using AutoMapper;
using MoviesApp.Models;
using System;

namespace MoviesApp.Services_.Dto.AutoMapperProfile
{
    public class MovieDtoProfile : Profile
    {
        public MovieDtoProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}