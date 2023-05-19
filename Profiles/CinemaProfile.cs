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
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco, 
                           opt => opt.MapFrom(cinema => cinema.Endereco))
                .ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();
        }
    }
}
