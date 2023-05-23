﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, CreateFilmeDto>().ReverseMap();
            CreateMap<Filme, UpdateFilmeDto>().ReverseMap();
            CreateMap<Filme, ReadFilmeDto>()
                .ForMember(filmeDto => filmeDto.Sessoes, 
                    opt => opt.MapFrom(filme => filme.Sessoes))
                .ReverseMap();
        }
    }
}
