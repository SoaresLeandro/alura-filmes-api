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
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();
            CreateMap<Cinema, ReadCinemaDto>()
               .ForMember(cinemaDto => cinemaDto.Endereco,
                          opt => opt.MapFrom(cinema => cinema.Endereco))
               .ForMember(cinemaDto => cinemaDto.Sessoes,
                          opt => opt.MapFrom(cinema => cinema.Sessoes))
               .ReverseMap();
        }
    }
}
