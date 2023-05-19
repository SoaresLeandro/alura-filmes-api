using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao, CreateSessaoDto>().ReverseMap();
            CreateMap<Sessao, ReadSessaoDto>().ReverseMap();
        }
    }
}
