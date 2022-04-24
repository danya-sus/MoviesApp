using AutoMapper;
using MoviesApp.Services_.Dto;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class ActorViewModelsProfile : Profile
    {
        public ActorViewModelsProfile()
        {
            CreateMap<ActorDto, InputActorViewModel>().ReverseMap();
            CreateMap<ActorDto, DeleteActorViewModel>();
            CreateMap<ActorDto, EditActorViewModel>().ReverseMap();
            CreateMap<ActorDto, ActorViewModel>();
        }
    }
}