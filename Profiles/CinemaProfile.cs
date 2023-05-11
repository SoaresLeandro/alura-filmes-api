using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
            CreateMap<Cinema, ReadCinemaDto>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();
        }
    }
}
